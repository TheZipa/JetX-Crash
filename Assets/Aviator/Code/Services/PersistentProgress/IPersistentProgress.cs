using Aviator.Code.Data.Progress;

namespace Aviator.Code.Services.PersistentProgress
{
    public interface IPersistentProgress
    {
        PlayerProgress Progress { get; set; }
    }
}