using System;

namespace Aviator.Code.Core.MultiplierRunner
{
    public interface IMultiplierRunner
    {
        void RunToMultiplier();
        event Action OnReached;
        float GetMultiplier();
    }
}