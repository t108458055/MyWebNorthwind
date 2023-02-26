namespace MyWebNorthwind.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> FetchAll();
        IQueryable<T> Query { get; }
        void Add(T entity);
        void Delete(T entity);
        void Save();
    }
}
