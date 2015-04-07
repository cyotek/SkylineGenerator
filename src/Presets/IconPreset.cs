using System.Drawing;

namespace Cyotek.SkylineGenerator.Presets
{
  internal class IconPreset : AnsdorPreset
  {
    #region Constructors

    public IconPreset()
    {
      this.AutoUpdate = false;
      this.Size = new Size(32, 32);
      foreach (BuildingStyle building in this.Buildings)
      {
        building.WindowSize = new Size(1, 1);
      }
      this.MinimumBuildingSize = new Size(2, 4);
      this.MaximumBuildingSize = new Size(8, 24);
      this.Density = 100;
      this.Seed = 32;
      this.Horizon = 16;
      this.Stars = new StarStyle
                   {
                     Density = 8,
                     Color = Color.FromArgb(128, Color.White),
                     Size = new Size(1, 1)
                   };
    }

    #endregion
  }
}
