using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Cyotek.SkylineGenerator.Annotations;
using Newtonsoft.Json;

namespace Cyotek.SkylineGenerator
{
  [TypeConverter(typeof(ExpandableObjectConverter))]
  [JsonObject]
  internal class StarStyle : INotifyPropertyChanged, ICloneable
  {
    #region Fields

    private Color _color;

    private int _density;

    private Size _size;

    #endregion

    #region Constructors

    public StarStyle()
    {
      this.Color = Color.White;
      this.Density = 20;
      this.Size = new Size(4, 4);
    }

    #endregion

    #region Properties

    [DefaultValue(typeof(Color), "White")]
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

    [DefaultValue(20)]
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
    [DefaultValue(typeof(Size), "4, 4")]
    public virtual Size Size
    {
      get { return _size; }
      set
      {
        if (this.Size != value)
        {
          _size = value;

          this.OnPropertyChanged();
        }
      }
    }

    #endregion

    #region Methods

    public StarStyle Clone()
    {
      return (StarStyle)this.MemberwiseClone();
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>
    /// A string that represents the current object.
    /// </returns>
    public override string ToString()
    {
      return this.Density > 0 ? string.Concat(this.Density.ToString(), " ", this.Color.ToHex()) : "None";
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
