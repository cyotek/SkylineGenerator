using System.Drawing;

namespace Cyotek.SkylineGenerator.Presets
{
  internal class GorillaPreset : SimpleSkylineGenerator
  {
    #region Constructors

    public GorillaPreset()
    {
      this.AutoUpdate = false;
      this.Background = new BackgroundStyle
                        {
                          StartColor = Color.Black,
                          EndColor = Color.Blue
                        };
      this.Buildings.Clear();
      this.Buildings.Add(new BuildingStyle
                         {
                           Color = Color.Black,
                           LightColor = Color.Yellow,
                           WindowSize = new Size(5, 5)
                         });
      this.Size = new Size(320, 200);
      this.Horizon = 100;
      this.MaximumBuildingSize = new Size(60, 180);
      this.Density = 50;
      this.Stars.Density = 0;
    }

    #endregion
  }
}
