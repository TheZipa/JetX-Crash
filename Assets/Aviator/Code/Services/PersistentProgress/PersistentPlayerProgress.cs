using Aviator.Code.Data.Progress;

namespace Aviator.Code.Services.PersistentProgress
{
    public class PersistentPlayerProgress : IPersistentProgress
    {
        public PlayerProgress Progress { get; set; }
    }
}