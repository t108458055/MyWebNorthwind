namespace MyWebNorthwind.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> FetchAll();
        IQueryable<T> Query { get; }
        T Get(int id);
        void Add(T entity);
        void Update(T entity);  
        void Delete(T entity);
        void Save();
    }
}
