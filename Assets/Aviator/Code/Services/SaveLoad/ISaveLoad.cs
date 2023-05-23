using Aviator.Code.Data.Progress;

namespace Aviator.Code.Services.SaveLoad
{
    public interface ISaveLoad
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}