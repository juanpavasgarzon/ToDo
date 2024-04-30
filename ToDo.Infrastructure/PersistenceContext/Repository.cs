using ToDo.Infrastructure.PersistenceContext.Contracts;

namespace ToDo.Infrastructure.PersistenceContext;

public class Repository : IRepository
{
    private readonly Dictionary<string, List<IEntity>> _context = new();

    private List<TEntity> GetEntityContext<TEntity>()
    {
        var name = typeof(TEntity).Name;
        if (!_context.ContainsKey(name))
        {
            _context[name] = [];
        }

        return _context[name].Cast<TEntity>().ToList();
    }

    public TEntity Add<TEntity>(TEntity entity) where TEntity : class, IEntity
    {
        var context = GetEntityContext<TEntity>();
        var type = entity.Id.GetType();

        object? id = null;
        if (type == typeof(int))
        {
            id = entity.Id = context.Count + 1;
        }

        if (type == typeof(string))
        {
            id = Guid.NewGuid().ToString();
        }

        entity.Id = id ?? throw new Exception("The Id Could Not Be Generated");
        context.Add(entity);
        return entity;
    }

    public TEntity AddWithoutId<TEntity>(TEntity entity) where TEntity : class, IEntity
    {
        var context = GetEntityContext<TEntity>();
        context.Add(entity);
        return entity;
    }

    public TEntity? GetById<TEntity, TKey>(TKey key) where TEntity : class, IEntity
    {
        var context = GetEntityContext<TEntity>();
        var entity = context.Find(x => x.Id.Equals(key));
        return entity;
    }

    public List<TEntity> GetBy<TEntity>(Predicate<TEntity> predicate) where TEntity : class, IEntity
    {
        var context = GetEntityContext<TEntity>();
        var entities = context.FindAll((Predicate<IEntity>)predicate);
        return entities;
    }

    public List<TEntity> GetAll<TEntity>() where TEntity : class, IEntity
    {
        var entities = GetEntityContext<TEntity>();
        return entities;
    }

    public bool RemoveById<TEntity, TKey>(TKey key) where TEntity : class, IEntity
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