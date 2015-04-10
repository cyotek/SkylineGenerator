using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using Cyotek.SkylineGenerator.Annotations;

namespace Cyotek.SkylineGenerator
{
  internal class SimpleSkylineGenerator : INotifyPropertyChanged
  {
    #region Fields

    private Random _buildingRandom;

    private Random _lightingRandom;

    private SimpleSkylineGeneratorSettings _settings;

    private Random _starsRandom;

    private Random _styleRandom;

    #endregion

    #region Constructors

    public SimpleSkylineGenerator()
    {
      this.Settings = new SimpleSkylineGeneratorSettings();
      this.AutoUpdate = true;
    }

    #endregion

    #region Events

    public event EventHandler Generated;

    /// <summary>
    /// Occurs when the Settings property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler SettingsChanged;

    #endregion

    #region Properties

    public int ActualSeed { get; protected set; }

    [DefaultValue(true)]
    public bool AutoUpdate { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Bitmap Image { get; protected set; }

    public SimpleSkylineGeneratorSettings Settings
    {
      get { return _settings; }
      set
      {
        if (this.Settings != value)
        {
          if (_settings != null)
          {
            _settings.PropertyChanged -= this.SettingsPropertyChangedHandler;
          }

          _settings = value;

          if (_settings != null)
          {
            _settings.PropertyChanged += this.SettingsPropertyChangedHandler;
          }

          this.OnSettingsChanged(EventArgs.Empty);
        }
      }
    }

    #endregion

    #region Methods

    public void Generate()
    {
      Bitmap bitmap;
      SimpleSkylineGeneratorSettings settings;
      int seed;

      settings = this.Settings;

      bitmap = new Bitmap(settings.Size.Width, settings.Size.Height, PixelFormat.Format32bppArgb);

      seed = settings.Seed == 0 ? Environment.TickCount : settings.Seed;

      _buildingRandom = new Random(seed);
      _lightingRandom = new Random(seed);
      _styleRandom = new Random(seed);
      _starsRandom = new Random(seed);
      this.ActualSeed = seed;

      using (Graphics g = Graphics.FromImage(bitmap))
      {
        this.DrawBackground(g);

        this.DrawBuildings(g);
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
      PropertyChangedEventHandler handler = this.PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    /// <summary>
    /// Raises the <see cref="SettingsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnSettingsChanged(EventArgs e)
    {
      EventHandler handler;

      this.GenerateIfEnabled();

      handler = this.SettingsChanged;

      if (handler != null)
      {
        handler(this, e);
      }
    }

    private void DrawBackground(Graphics g)
    {
      Rectangle bounds;
      SimpleSkylineGeneratorSettings settings;

      settings = this.Settings;

      bounds = new Rectangle(Point.Empty, settings.Size);

      using (Brush brush = new LinearGradientBrush(bounds, settings.Background.StartColor, settings.Background.EndColor, LinearGradientMode.Vertical))
      {
        g.FillRectangle(brush, bounds);
      }

      using (Brush brush = new SolidBrush(settings.Stars.Color))
      {
        for (int i = 0; i < settings.Stars.Density; i++)
        {
          int x;
          int y;

          x = _starsRandom.Next(0, bounds.Width - settings.Stars.Size.Width);
          y = _starsRandom.Next(0, settings.Horizon - settings.Stars.Size.Height);

          g.FillRectangle(brush, x, y, settings.Stars.Size.Width, settings.Stars.Size.Height);
        }
      }
    }

    private void DrawBuilding(Graphics g, BuildingStyle left, BuildingStyle right)
    {
      SimpleSkylineGeneratorSettings settings;

      settings = this.Settings;

      if (settings.MinimumBuildingSize.Width < settings.MaximumBuildingSize.Width && settings.MinimumBuildingSize.Height < settings.MaximumBuildingSize.Height)
      {
        Rectangle[] bounds;

        bounds = this.GetNewBuildingBounds(left, right);

        this.DrawBuilding(g, left, bounds[0]);
        if (right != null)
        {
          this.DrawBuilding(g, right, bounds[1]);
        }
      }
    }

    private void DrawBuilding(Graphics g, BuildingStyle style, Rectangle bounds)
    {
      using (Brush brush = new SolidBrush(style.Color))
      {
        g.FillRectangle(brush, bounds);
      }

      this.DrawLights(g, style, bounds);
    }

    private void DrawBuildings(Graphics g)
    {
      BuildingStyle[] buildingStyles;
      SimpleSkylineGeneratorSettings settings;
      settings = this.Settings;

      buildingStyles = settings.Buildings.ToArray();

      if (buildingStyles.Length != 0)
      {
        for (int i = 0; i < settings.Density; i++)
        {
          BuildingStyle left;
          BuildingStyle right;
          int leftIndex;

          leftIndex = _styleRandom.Next(0, buildingStyles.Length);
          left = buildingStyles[leftIndex];

          if (left.Mirror && buildingStyles.Length > 1)
          {
            int rightIndex;

            do
            {
              rightIndex = _styleRandom.Next(0, buildingStyles.Length);
            } while (leftIndex == rightIndex);

            right = buildingStyles[rightIndex];
          }
          else
          {
            right = null;
          }

          this.DrawBuilding(g, left, right);
        }
      }
    }

    private void DrawLights(Graphics g, BuildingStyle style, Rectangle bounds)
    {
      int windowWidth;
      int windowHeight;
      int right;
      SimpleSkylineGeneratorSettings settings;

      settings = this.Settings;

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

            lit = _lightingRandom.NextDouble() <= settings.LightingDensity;

            if (lit)
            {
              bool doubleWidth;
              int w;

              doubleWidth = style.GrowWindows && x + windowWidth <= right && _lightingRandom.NextDouble() >= 0.5;
              w = doubleWidth ? windowWidth * 2 : windowWidth;

              g.FillRectangle(brush, x, y, w, windowHeight);
            }
          }
        }

        //g.FillRectangle(brush, bounds.Left + windowWidth, bounds.Top + windowHeight, bounds.Width - (windowWidth * 2), bounds.Height);
      }
    }

    private void GenerateIfEnabled()
    {
      if (this.AutoUpdate)
      {
        this.Generate();
      }
    }

    private int GetBuildingWidth(BuildingStyle style)
    {
      SimpleSkylineGeneratorSettings settings;
      int offset;
      int result;
      //int maxW;

      settings = this.Settings;

      //maxW = settings.MaximumBuildingSize.Width / _buildingRandom.Next(1, 10);
      //result = maxW < settings.MinimumBuildingSize.Width ? settings.MinimumBuildingSize.Width : _buildingRandom.Next(settings.MinimumBuildingSize.Width, maxW);
      result = _buildingRandom.Next(settings.MinimumBuildingSize.Width, settings.MaximumBuildingSize.Width);

      offset = result % style.WindowSize.Width;
      result += offset;

      return result;
    }

    private Rectangle[] GetNewBuildingBounds(BuildingStyle left, BuildingStyle right)
    {
      int leftW;
      int rightW;
      int h;
      int x;
      int y;
      int maxH;
      int maxX;
      Rectangle leftBounds;
      Rectangle rightBounds;
      SimpleSkylineGeneratorSettings settings;

      settings = this.Settings;

      leftW = this.GetBuildingWidth(left);
      rightW = right != null ? this.GetBuildingWidth(right) : 0;

      maxH = settings.MaximumBuildingSize.Height / _buildingRandom.Next(1, 10);
      h = maxH < settings.MinimumBuildingSize.Height ? settings.MinimumBuildingSize.Height : _buildingRandom.Next(settings.MinimumBuildingSize.Height, maxH);
      //h= _buildingRandom.Next(settings.MinimumBuildingSize.Height, settings.MaximumBuildingSize.Height);

      maxX = settings.Size.Width - (leftW + rightW);

      if (settings.Wrap)
      {
        x = _buildingRandom.Next(0, maxX);
      }
      else
      {
        x = _buildingRandom.Next(-settings.MaximumBuildingSize.Width, maxX + (settings.MaximumBuildingSize.Width * 2));
      }

      y = settings.Size.Height - h;

      leftBounds = new Rectangle(x, y, leftW, h);
      rightBounds = new Rectangle(x + leftW, y, rightW, h);

      return new[]
             {
               leftBounds, rightBounds
             };
    }

    private void SettingsPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
    {
      this.GenerateIfEnabled();
    }

    #endregion

    #region INotifyPropertyChanged Interface

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion
  }
}
