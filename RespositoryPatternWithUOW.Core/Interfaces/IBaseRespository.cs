using RespositoryPatternWithUOW.Core.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryPatternWithUOW.Core.Interfaces
{
    public interface IBaseRespository<T> where T : class
    {
            T GetById(int id);
            Task<T> GetByIdAsync(int id);
            Task<IEnumerable<T>> GetByAllAsync();
            Task<T> Find(Expression<Func<T, bool>> criteria, string[] includes=null);
             Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
            Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip,
             Expression<Func<T, object>> orderBy = null, string orderByDirection = OrdesrBy.Ascending);
            Task<T> Add(T entity);
            Task<IEnumerable<T>> AddRange(IEnumerable<T> entity);
        T Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
