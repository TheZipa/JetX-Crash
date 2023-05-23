namespace Aviator.Code.Services.UserBalance
{
    public interface IUserBalance
    {
        void Add(double balance);
        void Minus(double balance);
        bool TryReset();
    }
}