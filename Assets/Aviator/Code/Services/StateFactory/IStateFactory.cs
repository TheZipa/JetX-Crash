using Aviator.Code.Infrastructure.StateMachine.States;

namespace Aviator.Code.Services.StateFactory
{
    public interface IStateFactory
    {
        T Create<T>() where T : IExitableState;
    }
}