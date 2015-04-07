using System.Drawing;

namespace Cyotek.SkylineGenerator.Presets
{
  internal class VectorCityPreset : SimpleSkylineGenerator
  {
    #region Constructors

    public VectorCityPreset()
    {
      this.AutoUpdate = false;
      this.Background = new BackgroundStyle
                        {
                          StartColor = Color.FromArgb(63, 30, 99),
                          EndColor = Color.FromArgb(101, 51, 162)
                        };
      this.Buildings = new BuildingStyleCollection();
      this.Buildings.Add(new BuildingStyle
                         {
                           Color = Color.Black,
                           LightColor = Color.FromArgb(23, 183, 231),
                           WindowSize = new Size(20, 40)
                         });
      this.Buildings.Add(new BuildingStyle
                         {
                           Color = Color.Black,
                           LightColor = Color.FromArgb(253, 174, 19),
                           WindowSize = new Size(20, 40)
                         });
      this.Size = new Size(1920, 1080);
      this.MaximumBuildingSize = new Size(300, 960);
      this.MinimumBuildingSize = new Size(100, 100);
      this.Density = 100;
      this.LightingDensity = 0.5;
      this.Horizon = this.Size.Height / 2;
      this.Stars = new StarStyle
                   {
                     Color = Color.FromArgb(128, Color.White),
                     Density = 20
                   };
    }

    #endregion
  }
}
