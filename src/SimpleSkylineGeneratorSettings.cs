using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Cyotek.SkylineGenerator.Annotations;
using Newtonsoft.Json;

namespace Cyotek.SkylineGenerator
{
  [JsonObject]
  internal class SimpleSkylineGeneratorSettings : INotifyPropertyChanged
  {
    #region Fields

    private BackgroundStyle _background;

    private BuildingStyleCollection _buildings;

    private int _density;

    private int _horizon;

    private double _lightingDensity;

    private Size _maximumBuildingSize;

    private Size _minimumBuildingSize;

    private int _seed;

    private Size _size;

    private StarStyle _stars;

    private bool _updatesLocked;

    private bool _wrap;

    #endregion

    #region Constructors

    public SimpleSkylineGeneratorSettings()
    {
      this.Background = new BackgroundStyle();
      this.Buildings = new BuildingStyleCollection();
      this.Buildings.Add(new BuildingStyle
                         {
                           Color = Color.FromArgb(37, 36, 90),
                           LightColor = Color.FromArgb(255, 254, 203),
                           GrowWindows = true
                         });
      this.Buildings.Add(new BuildingStyle
                         {
                           Color = Color.FromArgb(1, 0, 58),
                           LightColor = Color.FromArgb(74, 131, 171),
                           GrowWindows = true
                         });
      this.Size = new Size(1280, 720);
      this.MaximumBuildingSize = new Size(50, 210);
      this.MinimumBuildingSize = new Size(10, 20);
      this.Density = 500;
      this.LightingDensity = 0.5;
      this.Stars = new StarStyle();
      this.Horizon = 360;
      this.Wrap = true;
    }

    #endregion

    #region Properties

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

    [Category("")]
    [DefaultValue(true)]
    public virtual bool Wrap
    {
      get { return _wrap; }
      set
      {
        if (this.Wrap != value)
        {
          _wrap = value;

          this.OnPropertyChanged();
        }
      }
    }

    #endregion

    #region Methods

    public void CopyFrom(SimpleSkylineGeneratorSettings source)
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

      this.OnPropertyChanged("Seed");
    }

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      if (!_updatesLocked)
      {
        PropertyChangedEventHandler handler;

        handler = this.PropertyChanged;
        if (handler != null)
        {
          handler(this, new PropertyChangedEventArgs(propertyName));
        }
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
