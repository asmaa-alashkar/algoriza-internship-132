using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.Interfaces
{
    public interface IRepositoryApp<T> where T : class
    {
        #region main operation

        void Add(T entity);
        void AddRange(List<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

        #endregion

        #region GetById Async
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes);

        #endregion

        #region GetALL Async =>(IEnumerable)
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereCondition);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes);
        #endregion

        #region  GetALL Async =>(IQueryable)
        IQueryable<T> GetAll();

        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);

        IQueryable<T> GetAll(Expression<System.Func<T, bool>> whereCondition);

        IQueryable<T> GetAll(Expression<System.Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes);

        #endregion
        #region  Count Async =>(IQueryable)
        Task<double> Count();

        Task<double> Count(params Expression<Func<T, object>>[] includes);

        Task<double> Count(Expression<System.Func<T, bool>> whereCondition);

        Task<double> Count(Expression<System.Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes);

        #endregion

        #region SingleOrDefault Async
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> whereCondition);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes);
        Task<T> SingleOrDefaultAsNoTrackingAsync(Expression<Func<T, bool>> whereCondition);
        Task<T> SingleOrDefaultAsNoTrackingAsync(Expression<Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes);

        #endregion

        #region OrderBy
        IEnumerable<T> OrderBy(Expression<Func<T, bool>> whereCondition);
        IEnumerable<T> OrderByDescending(Expression<Func<T, bool>> whereCondition);
        #endregion

        #region SaveAllAsync
        Task<bool> SaveAllAsync();

        #endregion

        #region checkState
        public bool checkState(T entity, string state);

        #endregion
        #region Get first
        Task<T> FirstAsync();

        Task<T> FirstAsNoTrackingAsync();
        #endregion
        // 
      

    }
}
