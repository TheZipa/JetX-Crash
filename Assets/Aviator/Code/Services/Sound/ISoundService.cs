using Aviator.Code.Data.Enums;
using Aviator.Code.Data.Progress;
using Aviator.Code.Data.StaticData.Sounds;

namespace Aviator.Code.Services.Sound
{
    public interface ISoundService
    {
        void Construct(SoundData soundData, Settings userSettings);
        void PlayEffectSound(SoundId soundId);
        void SetBackgroundMusicVolume(float volume);
        void SetEffectsVolume(float volume);
        void PlayBackgroundMusic();
        void StopBackgroundMusic();
        bool MusicMuted { get; set; }
        bool EffectsMuted { get; set; }
    }
}