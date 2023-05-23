using Aviator.Code.Data.Progress;
using Aviator.Code.Extensions;
using Aviator.Code.Services.PersistentProgress;
using UnityEngine;

namespace Aviator.Code.Services.SaveLoad
{
    public class PrefsSaveLoad : ISaveLoad
    {
        private readonly IPersistentProgress _playerProgress;
        private const string ProgressKey = "Progress";

        public PrefsSaveLoad(IPersistentProgress playerProgress) => _playerProgress = playerProgress;
        
        public void SaveProgress() => 
            PlayerPrefs.SetString(ProgressKey, _playerProgress.Progress.ToJson());

        public PlayerProgress LoadProgress() =>
            PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();
    }
}