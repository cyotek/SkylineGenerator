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
  internal class BackgroundStyle : INotifyPropertyChanged, ICloneable
  {
    #region Fields

    private Color _endColor;

    private Color _startColor;

    #endregion

    #region Constructors

    public BackgroundStyle()
    {
      this.StartColor = Color.FromArgb(3, 0, 136);
      this.EndColor = Color.FromArgb(133, 0, 195);
    }

    #endregion

    #region Properties

    [DefaultValue(typeof(Color), "133, 0, 195")]
    public Color EndColor
    {
      get { return _endColor; }
      set
      {
        if (_endColor != value)
        {
          _endColor = value;

          this.OnPropertyChanged();
        }
      }
    }

    [DefaultValue(typeof(Color), "3, 0, 136")]
    public Color StartColor
    {
      get { return _startColor; }
      set
      {
        if (_startColor != value)
        {
          _startColor = value;

          this.OnPropertyChanged();
        }
      }
    }

    #endregion

    #region Methods

    public BackgroundStyle Clone()
    {
      return (BackgroundStyle)this.MemberwiseClone();
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>
    /// A string that represents the current object.
    /// </returns>
    public override string ToString()
    {
      return string.Concat(this.StartColor.ToHex(), " to ", this.EndColor.ToHex());
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
