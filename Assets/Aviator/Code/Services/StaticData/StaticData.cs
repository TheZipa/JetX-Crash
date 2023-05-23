using Aviator.Code.Data.StaticData;
using Aviator.Code.Data.StaticData.Sounds;
using Aviator.Code.Services.StaticData.StaticDataProvider;

namespace Aviator.Code.Services.StaticData
{
    public class StaticData : IStaticData
    {
        public SoundData SoundData { get; private set; }
        public AviatorSettingsConfig AviatorSettingsConfig { get; private set; }
        public AviatorPrefabs AviatorPrefabs { get; private set; }

        private readonly IStaticDataProvider _staticDataProvider;

        public StaticData(IStaticDataProvider staticDataProvider)
        {
            _staticDataProvider = staticDataProvider;
            LoadStaticData();
        }

        private void LoadStaticData()
        {
            AviatorSettingsConfig = _staticDataProvider.LoadAviatorSettingsConfig();
            AviatorPrefabs = _staticDataProvider.LoadAviatorPrefabs();
            SoundData = _staticDataProvider.LoadSoundData();
        }
    }
}