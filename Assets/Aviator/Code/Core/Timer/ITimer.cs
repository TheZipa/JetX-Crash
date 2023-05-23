using System;

namespace Aviator.Code.Core.Timer
{
    public interface ITimer
    {
        event Action OnExpired;
        void Start();
    }
}