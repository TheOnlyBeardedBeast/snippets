public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public bool Deleted { get; set; } = false;
    }

public interface IRepository<T> where T : class
    {
        //Read
        T Find(Expression<Func<T, bool>> predicate);
        List<T> All();
        List<T> Filter(Expression<Func<T, bool>> predicate);
        //Create
        T Add(T entity);
        Task<T> AddAsync(T entity);
        List<T> Add(List<T> entities);
        //Delete
        void Delete(T entity);
        void Delete(List<T> entities);
        //Update
        T Update(T entity);
        List<T> Update(List<T> entities);

    }


public class Repository<T> : IRepository<T> where T : class // the class on the end can be replaced with BaseEntity if all the models are based on that
    {
        protected readonly DbContext db;
        protected readonly DbSet<T> dbs;

        public Repository(DbContext db)
        {
            this.db = db;
            dbs = db.Set<T>();
        }

        public T Add(T entity)
        {
            dbs.Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbs.AddAsync(entity);
            return entity;
        }

        public List<T> Add(List<T> entities)
        {
            dbs.AddRange(entities);
            return entities;
        }

        public List<T> All()
        {
            return dbs.ToList();
        }

        public void Delete(T entity)
        {
            dbs.Remove(entity);
        }

        public void Delete(List<T> entities)
        {
            dbs.RemoveRange(entities);
        }

        public List<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return dbs.Where(predicate).ToList();
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return dbs.FirstOrDefault(predicate);
        }

        public T Update(T entity)
        {
            db.Attach(entity);
            dbs.Update(entity);
            return entity;
        }

        public List<T> Update(List<T> entities)
        {
            db.Attach(entities);
            dbs.UpdateRange(entities);
            return entities;
        }
    }
