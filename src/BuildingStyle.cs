using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Cyotek.SkylineGenerator.Annotations;
using Newtonsoft.Json;

namespace Cyotek.SkylineGenerator
{
  [JsonObject]
  internal class BuildingStyle : INotifyPropertyChanged, ICloneable
  {
    #region Fields

    private Color _color;

    private bool _growWindows;

    private Color _lightColor;

    private bool _mirror;

    private Size _windowSize;

    #endregion

    #region Constructors

    public BuildingStyle()
    {
      this.Color = Color.Black;
      this.LightColor = Color.Yellow;
      this.WindowSize = new Size(4, 4);
    }

    #endregion

    #region Properties

    [DefaultValue(typeof(Color), "Black")]
    public Color Color
    {
      get { return _color; }
      set
      {
        if (_color != value)
        {
          _color = value;

          this.OnPropertyChanged();
        }
      }
    }

    [Category("")]
    [DefaultValue(false)]
    public virtual bool GrowWindows
    {
      get { return _growWindows; }
      set
      {
        if (this.GrowWindows != value)
        {
          _growWindows = value;

          this.OnPropertyChanged();
        }
      }
    }

    [DefaultValue(typeof(Color), "Yellow")]
    public Color LightColor
    {
      get { return _lightColor; }
      set
      {
        if (_lightColor != value)
        {
          _lightColor = value;

          this.OnPropertyChanged();
        }
      }
    }

    [Category("")]
    [DefaultValue(false)]
    public virtual bool Mirror
    {
      get { return _mirror; }
      set
      {
        if (this.Mirror != value)
        {
          _mirror = value;

          this.OnPropertyChanged();
        }
      }
    }

    [DefaultValue(typeof(Size), "4, 4")]
    public virtual Size WindowSize
    {
      get { return _windowSize; }
      set
      {
        if (this.WindowSize != value)
        {
          _windowSize = value;

          this.OnPropertyChanged();
        }
      }
    }

    #endregion

    #region Methods

    public BuildingStyle Clone()
    {
      return (BuildingStyle)this.MemberwiseClone();
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

    #endregion

    #region ICloneable Interface

    object ICloneable.Clone()
    {
      return this.Clone();
    }

    #endregion

    #region INotifyPropertyChanged Interface

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion
  }
}
