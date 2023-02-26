using System.Linq.Expressions;

namespace MyWebNorthwind.Repositories
{
    //public class GitHubRepository<T> : IDisposable, IRepository<T> where T : class, IEntity
    //{
    //    private readonly DbContext _store;
    //    private readonly IEventLogger _logger;
    //    private DbSet<T> _set;
    //    public GitHubRepository(DbContext store, IEventLogger logger)
    //    {
    //        this._store = store;
    //        this._logger = logger;
    //    }

    //    protected DbSet<T> Set
    //    {
    //        get
    //        {
    //            if (this._set == null)
    //                this._set = this._store.Set<T>();
    //            return _set;
    //        }
    //    }

    //    //public virtual async Task<T> AddOrUpdateAsync(T entity)
    //    //{
    //    //    if (entity.Id == Guid.Empty)
    //    //    {
    //    //        entity.Id = Guid.NewGuid();
    //    //        this.Set.Add(entity);
    //    //        await this._store.SaveChangesAsync();
    //    //    }
    //    //    else
    //    //    {
    //    //        await UpdateAsync(entity);
    //    //    }
    //    //    return entity;
    //    //}

    //    protected virtual async Task UpdateAsync(T entity)
    //    {
    //        var itemToUpdate = await this.Set.AnyAsync(i => i.Id == entity.Id);
    //        if (itemToUpdate == false)
    //            throw new KeyNotFoundException("Could not find the item to update");
    //        var entry = this._store.Entry<T>(entity);

    //        try
    //        {
    //            if (entry.State == EntityState.Detached)
    //            {
    //                this.Set.Attach(entity);
    //            }
    //            entry.State = EntityState.Modified;
    //        }
    //        catch (Exception ex)
    //        {
    //            this._logger.Error(ex);

    //            throw;
    //        }
    //        var changes = await this._store.SaveChangesAsync();
    //        Debug.WriteLine(changes + " changes saved...");
    //    }
        
    //    public virtual async Task DeleteAsync(T entity)
    //    {
    //        this.Set.Remove(entity);
    //        await this._store.SaveChangesAsync();
    //    }

    //    public virtual async Task<IEnumerable<T>> RemoveRangeAsync(IEnumerable<T> entities)
    //    {

    //        this.Set.RemoveRange(entities);
    //        var changes = await this._store.SaveChangesAsync();
    //        this._logger.Debug(changes + " Changes saved.");
    //        return entities;
    //    }

    //    public virtual IQueryable<T> Query(Expression<Func<T, bool>> predicate) => this.Set.Where(predicate);

    //    public virtual IQueryable<T> GetAll() => this.Set;

    //    public virtual async Task<T> GetByIdAsync(Guid id)
    //    {
    //        var item = await this.Set.FindAsync(id);
    //        return item;
    //    }

    //    public virtual void Dispose()
    //    {
    //        this._store.Dispose();
    //    }

    //}
}
