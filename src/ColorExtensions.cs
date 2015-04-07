using System.Drawing;

namespace Cyotek.SkylineGenerator
{
  internal static class ColorExtensions
  {
    #region Static Methods

    internal static string ToHex(this Color color)
    {
      return string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
    }

    #endregion
  }
}
