namespace ToDo.Infrastructure.PersistenceContext.Contracts;

public interface IRepository
{
    public TEntity Add<TEntity>(TEntity entity) where TEntity : class, IEntity;

    public bool Update<TEntity>(TEntity entity) where TEntity : class, IEntity;

    public TEntity? GetById<TEntity>(int key) where TEntity : class, IEntity;

    public List<TEntity> GetBy<TEntity>(Func<TEntity, bool> predicate) where TEntity : class, IEntity;

    public List<TEntity> GetAll<TEntity>() where TEntity : class, IEntity;

    public bool RemoveById<TEntity>(int key) where TEntity : class, IEntity;

    public bool Remove<TEntity>(TEntity entity) where TEntity : class, IEntity;
}