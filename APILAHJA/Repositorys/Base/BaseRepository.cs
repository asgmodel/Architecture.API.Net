using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace APILAHJA.Repositorys.Base
{
    public interface IBaseRepository<T> where T : class
    {
        long CounItems { get; }

        //IQueryable<T> SetSkipAndTake(IQueryable<T> entry, int skip, int take);
        Task<T> GetByAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IQueryable<T>>? setInclude = null, bool tracked = false);
        Task<T?> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> AttachAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveAsync(Expression<Func<T, bool>> predicate);
        Task RemoveRange(List<T> entities);
        Task<int> SaveAsync();
        Task<bool> Exists(Expression<Func<T, bool>> filter);
        IBaseRepository<T> Include(Func<IQueryable<T>, IQueryable<T>> include);
        IBaseRepository<T> Includes(params string[] includes);
        IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, string[]? includes = null, int skip = 0, int take = 0, bool isOrdered = false, Expression<Func<T, long>>? order = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? include = null, int skip = 0, int take = 0, Expression<Func<T, object>>? order = null);
        Task RemoveAllAsync();
        //IQueryable<T> FromSqlRaw(string query, params SqlParameter[] parameters);
        IQueryable<T> Get(Expression<Func<T, bool>>? expression = null);
    }
    public sealed class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _db;
        private readonly DbSet<T> _dbSet;

        public long CounItems { get => _count; }
        private long _count = 0;
        IQueryable<T> query;

        public DbSet<T> DbSet => _dbSet;
        public BaseRepository(DbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
            query = _dbSet.AsQueryable();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>>? expression = null)
        {
            if (expression != null) query = query.Where(expression);
            return query;
        }

      

        public IBaseRepository<T> Include(Func<IQueryable<T>, IQueryable<T>> include)
        {
            query = include(Get());
            return this;
        }

        public IBaseRepository<T> Includes(params string[] includes)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return this;
        }

        public  async Task<T> GetByAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IQueryable<T>>? setInclude = null, bool tracked = false)
        {
            if (!tracked) query = query.AsNoTracking();

            if (filter != null) query = query.Where(filter);

            if (setInclude != null)
            {
                query = setInclude(query);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? include = null,
            int skip = 0, int take = 0, Expression<Func<T, object>>? order = null)
        {
            query = query.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            _count = await query.CountAsync();

            query = SetSkipAndTake(query, skip, take);
            if (order != null) query = query.OrderByDescending(order);

            if (include != null)
            {
                Include(include);
            }
            return await query.ToListAsync();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, string[]? includes = null,
        int skip = 0, int take = 0, bool isOrdered = false, Expression<Func<T, long>>? order = null)
        {

            if (filter != null)
            {
                query = _dbSet.Where(filter);
            }
            _count = query.Count();

            query = SetSkipAndTake(query, skip, take);

            if (isOrdered) { query.OrderByDescending(order); }

            if (includes != null)
            {
                Includes(includes);
            }
            return query;
        }

        public  async Task<T?> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            if (await SaveAsync() > 0)
                return entity;
            return null;
        }

        public  async Task<T> UpdateAsync(T entity)
        {
            _db.ChangeTracker.Clear();
            _dbSet.Update(entity);
            // «›’· «·ﬂ«∆‰ „‰ `DbContext` »⁄œ «· ÕœÌÀ
            //_dbSet.Entry(entity).State = EntityState.Detached;
            await SaveAsync();
            return entity;
        }


        public  async Task<T> AttachAsync(T entity)
        {
            //_db.ChangeTracker.Clear();
            _dbSet.Attach(entity);
            await SaveAsync();
            return entity;
        }

        public  async Task RemoveAsync(T entity)
        {
            if (_dbSet.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task RemoveAsync(Expression<Func<T, bool>> predicate)
        {
            await _dbSet.Where(predicate).ExecuteDeleteAsync();
        }

        public async Task RemoveAllAsync()
        {
            await _dbSet.ExecuteDeleteAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task RemoveRange(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await SaveAsync();
        }

        public static IQueryable<T> SetSkipAndTake(IQueryable<T> query, int skip, int take)
        {
            if (skip >= 0)
                query = query.Skip(skip);
            if (take > 0)
                query = query.Take(take);

            return query;
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> filter) => await _dbSet.AnyAsync(filter);
    }


}
