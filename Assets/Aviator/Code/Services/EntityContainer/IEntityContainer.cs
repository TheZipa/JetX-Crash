namespace Aviator.Code.Services.EntityContainer
{
    public interface IEntityContainer
    {
        void RegisterEntity<TEntity>(TEntity entity) where TEntity : class;
        TEntity GetEntity<TEntity>();
    }
}