using Aviator.Code.Data.StaticData;
using Aviator.Code.Data.StaticData.Sounds;

namespace Aviator.Code.Services.StaticData.StaticDataProvider
{
    public interface IStaticDataProvider
    {
        AviatorSettingsConfig LoadAviatorSettingsConfig();
        AviatorPrefabs LoadAviatorPrefabs();
        SoundData LoadSoundData();
    }
}