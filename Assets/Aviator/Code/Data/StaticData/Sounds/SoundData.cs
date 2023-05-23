using UnityEngine;

namespace Aviator.Code.Data.StaticData.Sounds
{
    [CreateAssetMenu(fileName = "Sound Data", menuName = "Static Data/Sound Data")]
    public class SoundData : ScriptableObject
    {
        public AudioClipData[] AudioEffectClips;
        public AudioClip BackgroundMusic;
    }
}