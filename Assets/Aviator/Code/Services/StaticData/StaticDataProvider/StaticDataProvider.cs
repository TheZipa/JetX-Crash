using Aviator.Code.Data.StaticData;
using Aviator.Code.Data.StaticData.Sounds;
using UnityEngine;

namespace Aviator.Code.Services.StaticData.StaticDataProvider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        private const string AviatorSettingsConfigPath = "StaticData/Aviator Settings Config";
        private const string AviatorPrefabsPath = "StaticData/Aviator Prefabs";
        private const string SoundDataPath = "StaticData/Sound Data";

        public AviatorSettingsConfig LoadAviatorSettingsConfig() =>
            Resources.Load<AviatorSettingsConfig>(AviatorSettingsConfigPath);

        public AviatorPrefabs LoadAviatorPrefabs() =>
            Resources.Load<AviatorPrefabs>(AviatorPrefabsPath);

        public SoundData LoadSoundData() =>
            Resources.Load<SoundData>(SoundDataPath);
    }
}