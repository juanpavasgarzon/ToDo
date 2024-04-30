using ToDo.Infrastructure.PersistenceContext.Contracts;

namespace ToDo.Infrastructure.PersistenceContext;

public class Repository : IRepository
{
    private readonly Dictionary<string, List<IEntity>> _context = new();

    private List<IEntity> GetEntityContext<TEntity>() where TEntity : class, IEntity
    {
        var name = typeof(TEntity).Name;
        if (!_context.ContainsKey(name))
        {
            _context[name] = [];
        }

        return _context[name];
    }

    public TEntity Add<TEntity>(TEntity entity) where TEntity : class, IEntity
    {
        var context = GetEntityContext<TEntity>();
        entity.Id = context.Count + 1;
        context.Add(entity);
        return entity;
    }

    public bool Update<TEntity>(TEntity entity) where TEntity : class, IEntity
    {
        var context = GetEntityContext<TEntity>();
        var original = context.Find(x => x.Id.Equals(entity.Id));
        if (original is null)
        {
            return false;
        }

        context.Remove(entity);
        context.Add(entity);
        return true;
    }

    public TEntity? GetById<TEntity>(int key) where TEntity : class, IEntity
    {
        var context = GetEntityContext<TEntity>();
        var entity = context.Find(x => x.Id.Equals(key));
        return entity as TEntity;
    }

    public List<TEntity> GetBy<TEntity>(Predicate<TEntity> predicate) where TEntity : class, IEntity
    {
        var context = GetEntityContext<TEntity>();
        var entities = context.FindAll((Predicate<IEntity>)predicate);
        return entities.OfType<TEntity>().ToList();
    }

    public List<TEntity> GetAll<TEntity>() where TEntity : class, IEntity
    {
        var entities = GetEntityContext<TEntity>();
        return entities.OfType<TEntity>().ToList();
    }

    public bool RemoveById<TEntity>(int key) where TEntity : class, IEntity
    {
        var context = GetEntityContext<TEntity>();
        var entity = context.Find(x => x.Id.Equals(key));
        if (entity is null)
        {
            return false;
        }

        return context.Remove(entity);
    }

    public bool Remove<TEntity>(TEntity entity) where TEntity : class, IEntity
    {
        var context = GetEntityContext<TEntity>();
        return context.Remove(entity);
    }
}