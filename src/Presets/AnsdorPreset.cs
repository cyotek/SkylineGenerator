using System.Drawing;

namespace Cyotek.SkylineGenerator.Presets
{
  internal class AnsdorPreset : SimpleSkylineGenerator
  {
    #region Constructors

    public AnsdorPreset()
    {
      this.AutoUpdate = false;
      this.Background = new BackgroundStyle
                        {
                          StartColor = Color.FromArgb(3, 0, 136),
                          EndColor = Color.FromArgb(133, 0, 195)
                        };
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
      this.Density = 1000;
      this.LightingDensity = 0.5;
      this.Horizon = 360;
      this.Stars = new StarStyle
                   {
                     Color = Color.White,
                     Density = 20
                   };
    }

    #endregion
  }
}
