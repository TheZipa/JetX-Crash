namespace Aviator.Code.Infrastructure.StateMachine.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }

    public interface IPayloadedState : IExitableState
    {
        void Enter(object payload);
    }

    public interface IExitableState
    {
        void Exit();
    }
}