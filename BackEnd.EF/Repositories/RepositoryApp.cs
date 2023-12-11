using BackEnd.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.EF.Repositories
{
    public class RepositoryApp<T>:IRepositoryApp<T> where T : class
    {
        protected readonly BackEndDBContext _db;
        protected DbSet<T> Entity=null;
        public RepositoryApp(BackEndDBContext db) 
        {
            _db=db;
            Entity=_db.Set<T>();    
        }
        #region main operation
        public void Add(T entity)
        {
          Entity.Add(entity);   
        }

        public void AddRange(List<T> entities)
        {
            Entity.AddRange(entities);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            Entity.UpdateRange(entities);
        }
        public void Update(T entity)
        {
            var x = Entity.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            Entity.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            Entity.RemoveRange(entities);
        }

        #endregion

        #region GetALL Async =>(IQueryable)
        public IQueryable<T> GetAll()
        {
            return Entity;
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var result = Entity.Where(i => true);


            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);

            return result;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            return Entity.Where(whereCondition);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes)
        {
            var result = Entity.Where(whereCondition);
            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);
            return result;
        }

        #endregion

        #region GetALL Async =>(IQueryable)
        public async Task<double> Count()
        {
            return await Entity.CountAsync();
        }

        public async Task<double> Count(params Expression<Func<T, object>>[] includes)
        {
            var result = Entity.Where(i => true);

            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);

            return await result.CountAsync();
        }

        public async Task<double> Count(Expression<Func<T, bool>> whereCondition)
        {
            return await Entity.Where(whereCondition).CountAsync();
        }

        public async Task<double> Count(Expression<Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes)
        {
            var result = Entity.Where(whereCondition);
            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);
            return await result.CountAsync(); ;
        }

        #endregion

        #region GetALL Async =>(IEnumerable)

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entity.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var result = Entity.Where(i => true);
            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);
            return await result.ToListAsync(); ;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereCondition)
        {
            return await Entity.Where(whereCondition).ToListAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes)
        {
            var result = Entity.Where(whereCondition);
            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);
            return await result.ToListAsync();
        }

        #endregion

        #region GetById Async  

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Entity.FindAsync(id);

        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await Entity.FindAsync(id);

        }
        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes)
        {
            var result = Entity.Where(whereCondition);
            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);
            return await result.FirstOrDefaultAsync();

        }



        #endregion

        #region  SingleOrDefaultAsync
        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> whereCondition)
        {
            return await Entity.Where(whereCondition).FirstOrDefaultAsync();
        }
        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes)
        {
            var result = Entity.Where(whereCondition);
            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);

            return await result.FirstOrDefaultAsync();
        }
        public async Task<T> SingleOrDefaultAsNoTrackingAsync(Expression<Func<T, bool>> whereCondition)
        {
            return await Entity.Where(whereCondition).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<T> SingleOrDefaultAsNoTrackingAsync(Expression<Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes)
        {
            var result = Entity.Where(whereCondition);
            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);

            return await result.AsNoTracking().FirstOrDefaultAsync();
        }
        #endregion

        #region OrderBy
        public IEnumerable<T> OrderBy(Expression<Func<T, bool>> whereCondition)
        {
            return Entity.OrderBy(whereCondition);
        }
        public IEnumerable<T> OrderByDescending(Expression<Func<T, bool>> whereCondition)
        {
            return Entity.OrderByDescending(whereCondition);
        }
        #endregion


        #region SaveAllAsync
        public async Task<bool> SaveAllAsync()
        {


            return await _db.SaveChangesAsync() > 0;

        }


        #endregion
        #region checkState
        public bool checkState(T entity, string state)
        {
            var x = _db.Entry(entity).State;
            return (_db.Entry(entity).State.ToString().ToLower() == state.ToLower().Trim()) ? true : false;
        }

        public DbSet<T> GetContext()
        {
            return Entity;

        }

        public async Task<T> FirstAsync()
        {
            return await Entity.FirstOrDefaultAsync();
        }
        public async Task<T> FirstAsNoTrackingAsync()
        {
            return await Entity.AsNoTracking().FirstOrDefaultAsync();
        }
        


        #endregion
    }
}
