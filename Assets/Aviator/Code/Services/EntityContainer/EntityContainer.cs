using System;
using System.Collections.Generic;

namespace Aviator.Code.Services.EntityContainer
{
    public class EntityContainer : IEntityContainer, IDisposable
    {
        private readonly Dictionary<Type, object> _entities = new Dictionary<Type, object>(10);

        public void RegisterEntity<TEntity>(TEntity entity) where TEntity : class
        {
            if (_entities.ContainsKey(typeof(TEntity)))
                ReplaceEntityWithDispose(entity);
            else
                _entities.Add(typeof(TEntity), entity);
        }

        public TEntity GetEntity<TEntity>()
        {
            _entities.TryGetValue(typeof(TEntity), out object entity);
            return (TEntity) entity;
        }

        public void Dispose()
        {
            foreach (var entity in _entities.Values)
                TryDisposeEntity(entity);
        }

        private void ReplaceEntityWithDispose<TEntity>(TEntity entity)
        {
            object replaceEntity = _entities[typeof(TEntity)];
            TryDisposeEntity(replaceEntity);
            _entities[typeof(TEntity)] = entity;
        }

        private void TryDisposeEntity(object entity)
        {
            if(entity is IDisposable disposableEntity) 
                disposableEntity.Dispose();
        }
    }
}