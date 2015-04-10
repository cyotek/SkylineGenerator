using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using Cyotek.SkylineGenerator.Annotations;

namespace Cyotek.SkylineGenerator
{
  internal class SimpleSkylineGenerator : Component, INotifyPropertyChanged
  {
    #region Fields

    private BackgroundStyle _background;

    private Random _buildingRandom;

    private BuildingStyleCollection _buildings;

    private int _density;

    private int _horizon;

    private double _lightingDensity;

    private Random _lightingRandom;

    private Size _maximumBuildingSize;

    private Size _minimumBuildingSize;

    private int _seed;

    private Size _size;

    private StarStyle _stars;

    private Random _starsRandom;

    private Random _styleRandom;

    private bool _updatesLocked;

    #endregion

    #region Constructors

    public SimpleSkylineGenerator()
    {
      this.Background = new BackgroundStyle();
      this.Buildings = new BuildingStyleCollection();
      this.Buildings.Add(new BuildingStyle
                         {
                           Color = Color.FromArgb(37, 36, 90),
                           LightColor = Color.FromArgb(255, 254, 203)
                         });
      this.Buildings.Add(new BuildingStyle
                         {
                           Color = Color.FromArgb(1, 0, 58),
                           LightColor = Color.FromArgb(74, 131, 171)
                         });
      this.Size = new Size(1280, 720);
      this.MaximumBuildingSize = new Size(50, 210);
      this.MinimumBuildingSize = new Size(10, 20);
      this.Density = 500;
      this.LightingDensity = 0.5;
      this.Stars = new StarStyle();
      this.Horizon = 360;
      this.AutoUpdate = true;
    }

    #endregion

    #region Events

    public event EventHandler Generated;

    #endregion

    #region Properties

    [DefaultValue(true)]
    public bool AutoUpdate { get; set; }

    [NotifyParentProperty(true)]
    public BackgroundStyle Background
    {
      get { return _background; }
      set
      {
        if (_background != null)
        {
          _background.PropertyChanged -= this.BackgroundPropertyChangedHandler;
        }

        _background = value;

        if (_background != null)
        {
          _background.PropertyChanged += this.BackgroundPropertyChangedHandler;
        }

        this.OnPropertyChanged();
      }
    }

    [NotifyParentProperty(true)]
    public BuildingStyleCollection Buildings
    {
      get { return _buildings; }
      set
      {
        if (_buildings != null)
        {
          _buildings.CollectionChanged -= this.BuildingsCollectionChangedHandler;
          _buildings.PropertyChanged -= this.BuildingsPropertyChangedHandler;
        }

        _buildings = value;

        if (_buildings != null)
        {
          _buildings.CollectionChanged += this.BuildingsCollectionChangedHandler;
          _buildings.PropertyChanged += this.BuildingsPropertyChangedHandler;
        }
      }
    }

    [DefaultValue(500)]
    public int Density
    {
      get { return _density; }
      set
      {
        if (_density != value)
        {
          _density = value;

          this.OnPropertyChanged();
        }
      }
    }

    [Category("")]
    [DefaultValue(360)]
    public virtual int Horizon
    {
      get { return _horizon; }
      set
      {
        if (this.Horizon != value)
        {
          _horizon = value;

          this.OnPropertyChanged();
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Bitmap Image { get; protected set; }

    [Category("")]
    [DefaultValue(0.5)]
    public double LightingDensity
    {
      get { return _lightingDensity; }
      set
      {
        _lightingDensity = value;

        this.OnPropertyChanged();
      }
    }

    [DefaultValue(typeof(Size), "50, 210")]
    public Size MaximumBuildingSize
    {
      get { return _maximumBuildingSize; }
      set
      {
        if (_maximumBuildingSize != value)
        {
          _maximumBuildingSize = value;

          this.OnPropertyChanged();
        }
      }
    }

    [DefaultValue(typeof(Size), "10, 20")]
    public Size MinimumBuildingSize
    {
      get { return _minimumBuildingSize; }
      set
      {
        if (_minimumBuildingSize != value)
        {
          _minimumBuildingSize = value;

          this.OnPropertyChanged();
        }
      }
    }

    [DefaultValue(0)]
    public int Seed
    {
      get { return _seed; }
      set
      {
        if (_seed != value)
        {
          _seed = value;

          this.OnPropertyChanged();
        }
      }
    }

    [DefaultValue(typeof(Size), "1280, 720")]
    public Size Size
    {
      get { return _size; }
      set
      {
        if (_size != value)
        {
          _size = value;

          this.OnPropertyChanged();
        }
      }
    }

    [NotifyParentProperty(true)]
    public StarStyle Stars
    {
      get { return _stars; }
      set
      {
        if (_stars != null)
        {
          _stars.PropertyChanged -= this.StarsPropertyChangedHandler;
        }

        _stars = value;

        if (_stars != null)
        {
          _stars.PropertyChanged += this.StarsPropertyChangedHandler;
        }

        this.OnPropertyChanged();
      }
    }

    #endregion

    #region Methods

    public void CopyFrom(SimpleSkylineGenerator source)
    {
      try
      {
        _updatesLocked = true;
        this.Background = source.Background.Clone();
        this.Buildings = new BuildingStyleCollection();
        foreach (BuildingStyle building in source.Buildings)
        {
          this.Buildings.Add(building.Clone());
        }
        this.Size = source.Size;
        this.MaximumBuildingSize = source.MaximumBuildingSize;
        this.MinimumBuildingSize = source.MinimumBuildingSize;
        this.Density = source.Density;
        this.LightingDensity = source.LightingDensity;
        this.Horizon = source.Horizon;
        this.Stars = source.Stars.Clone();
        this.Seed = source.Seed;
      }
      finally
      {
        _updatesLocked = false;
      }

      if (this.AutoUpdate)
      {
        this.Generate();
      }
    }

    public void Generate()
    {
      Bitmap bitmap;
      int buildingCount;

      bitmap = new Bitmap(this.Size.Width, this.Size.Height, PixelFormat.Format32bppArgb);

      _buildingRandom = this.Seed == 0 ? new Random() : new Random(this.Seed);
      _lightingRandom = this.Seed == 0 ? new Random() : new Random(this.Seed);
      _styleRandom = this.Seed == 0 ? new Random() : new Random(this.Seed);
      _starsRandom = this.Seed == 0 ? new Random() : new Random(this.Seed);
      buildingCount = this.Buildings.Count;

      using (Graphics g = Graphics.FromImage(bitmap))
      {
        this.DrawBackground(g);

        for (int i = 0; i < this.Density; i++)
        {
          int buildingStyleIndex;

          buildingStyleIndex = _styleRandom.Next(0, buildingCount);

          if (buildingStyleIndex < this.Buildings.Count)
          {
            this.DrawBuilding(g, this.Buildings[buildingStyleIndex]);
          }
        }
      }

      this.Image = bitmap;

      this.OnGenerated(EventArgs.Empty);
    }

    /// <summary>
    /// Raises the <see cref="Generated" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnGenerated(EventArgs e)
    {
      EventHandler handler;

      handler = this.Generated;

      if (handler != null)
      {
        handler(this, e);
      }
    }

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChangedEventHandler handler;

      if (this.AutoUpdate && !_updatesLocked)
      {
        this.Generate();
      }

      handler = this.PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    private void BackgroundPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
    {
      this.OnPropertyChanged("Background");
    }

    private void BuildingsCollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
    {
      this.OnPropertyChanged("Buildings");
    }

    private void BuildingsPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
    {
      this.OnPropertyChanged("Buildings");
    }

    private void DrawBackground(Graphics g)
    {
      Rectangle bounds;

      bounds = new Rectangle(Point.Empty, this.Size);

      using (Brush brush = new LinearGradientBrush(bounds, this.Background.StartColor, this.Background.EndColor, LinearGradientMode.Vertical))
      {
        g.FillRectangle(brush, bounds);
      }

      using (Brush brush = new SolidBrush(this.Stars.Color))
      {
        for (int i = 0; i < this.Stars.Density; i++)
        {
          int x;
          int y;

          x = _starsRandom.Next(0, bounds.Width - this.Stars.Size.Width);
          y = _starsRandom.Next(0, this.Horizon - this.Stars.Size.Height);

          g.FillRectangle(brush, x, y, this.Stars.Size.Width, this.Stars.Size.Height);
        }
      }
    }

    private void DrawBuilding(Graphics g, BuildingStyle style)
    {
      if (this.MinimumBuildingSize.Width < this.MaximumBuildingSize.Width && this.MinimumBuildingSize.Height < this.MaximumBuildingSize.Height)
      {
        int w;
        int h;
        int x;
        int y;
        int maxH;
        int offset;
        Rectangle bounds;

        maxH = this.MaximumBuildingSize.Height / _buildingRandom.Next(1, 10);
        w = _buildingRandom.Next(this.MinimumBuildingSize.Width, this.MaximumBuildingSize.Width);
        offset = w % style.WindowSize.Width;
        w += offset;
        h = maxH < this.MinimumBuildingSize.Height ? this.MinimumBuildingSize.Height : _buildingRandom.Next(this.MinimumBuildingSize.Height, maxH);
        x = _buildingRandom.Next(-this.MaximumBuildingSize.Width, this.Size.Width + (this.MaximumBuildingSize.Width * 2));
        y = this.Size.Height - h;
        bounds = new Rectangle(x, y, w, h);

        using (Brush brush = new SolidBrush(style.Color))
        {
          g.FillRectangle(brush, bounds);
        }

        this.DrawLights(g, style, bounds);
      }
    }

    private void DrawLights(Graphics g, BuildingStyle style, Rectangle bounds)
    {
      int windowWidth;
      int windowHeight;
      int right;

      windowWidth = style.WindowSize.Width;
      windowHeight = style.WindowSize.Height;
      right = bounds.Right - windowWidth;

      using (Brush brush = new SolidBrush(style.LightColor))
      {
        for (int y = bounds.Top + windowHeight; y < bounds.Bottom; y += (windowHeight * 2))
        {
          for (int x = bounds.Left + windowWidth; x < right; x += (windowWidth * 2))
          {
            bool lit;

            lit = _lightingRandom.NextDouble() <= this.LightingDensity;

            if (lit)
            {
              bool doubleWidth;
              int w;

              doubleWidth = x + windowWidth <= right && _lightingRandom.NextDouble() >= 0.5;
              doubleWidth = false;
              w = doubleWidth ? windowWidth * 2 : windowWidth;

              g.FillRectangle(brush, x, y, w, windowHeight);
            }
          }
        }

        //g.FillRectangle(brush, bounds.Left + windowWidth, bounds.Top + windowHeight, bounds.Width - (windowWidth * 2), bounds.Height);
      }
    }

    private void StarsPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
    {
      this.OnPropertyChanged("Stars");
    }

    #endregion

    #region INotifyPropertyChanged Interface

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion
  }
}
