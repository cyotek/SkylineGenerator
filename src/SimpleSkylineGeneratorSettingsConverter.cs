using System;
using Newtonsoft.Json.Converters;

namespace Cyotek.SkylineGenerator
{
  internal class SimpleSkylineGeneratorSettingsConverter : CustomCreationConverter<SimpleSkylineGeneratorSettings>
  {
    #region Methods

    /// <summary>
    /// Creates an object which will then be populated by the serializer.
    /// </summary>
    /// <param name="objectType">Type of the object.</param>
    /// <returns>
    /// The created object.
    /// </returns>
    public override SimpleSkylineGeneratorSettings Create(Type objectType)
    {
      SimpleSkylineGeneratorSettings settings;

      settings = new SimpleSkylineGeneratorSettings();
      settings.Buildings.Clear();

      return settings;
    }

    #endregion
  }
}
