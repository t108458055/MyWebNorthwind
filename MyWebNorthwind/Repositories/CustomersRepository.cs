namespace MyWebNorthwind.Repositories
{
    public class CustomersRepository<T> : IRepository<T> where T : class
    {
        public IQueryable<T> Query => throw new NotImplementedException();
        private readonly NorDBContext _dbContext;
        public CustomersRepository()
        {            
            _dbContext = new NorDBContext();
        }
        public T Get(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;  
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            var enity =_dbContext.Set<T>().DefaultIfEmpty(entity);
            if (enity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                _dbContext.SaveChanges();
            }
        }

        public List<T> FetchAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

   
    }
}
