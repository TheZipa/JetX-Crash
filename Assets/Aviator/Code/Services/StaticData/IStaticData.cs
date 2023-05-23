using Aviator.Code.Data.StaticData;
using Aviator.Code.Data.StaticData.Sounds;

namespace Aviator.Code.Services.StaticData
{
    public interface IStaticData
    {
        SoundData SoundData { get; }
        AviatorSettingsConfig AviatorSettingsConfig { get; }
        AviatorPrefabs AviatorPrefabs { get; }
    }
}