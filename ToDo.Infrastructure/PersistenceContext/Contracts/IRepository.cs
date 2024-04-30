namespace ToDo.Infrastructure.PersistenceContext.Contracts;

public interface IRepository
{
    public TEntity Add<TEntity>(TEntity entity) where TEntity : class, IEntity;

    public TEntity AddWithoutId<TEntity>(TEntity entity) where TEntity : class, IEntity;

    public TEntity? GetById<TEntity, TKey>(TKey key) where TEntity : class, IEntity;

    public List<TEntity> GetBy<TEntity>(Predicate<TEntity> predicate) where TEntity : class, IEntity;

    public List<TEntity> GetAll<TEntity>() where TEntity : class, IEntity;

    public bool RemoveById<TEntity, TKey>(TKey key) where TEntity : class, IEntity;

    public bool Remove<TEntity>(TEntity entity) where TEntity : class, IEntity;
}