using Microsoft.EntityFrameworkCore;
using RespositoryPatternWithUOW.Core.Consts;
using RespositoryPatternWithUOW.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryPatternWithUOW.EF.Respositories
{
    public class BaseRespository<T> : IBaseRespository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRespository(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<T>> GetByAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {

            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result;
        }
        public async Task<T> Find(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
           
            IQueryable<T> query = _context.Set<T>();
              // optinal get all includes(tabels in relation with entity)
            if(includes != null)
                foreach (var include in includes)
                    query = query.Include(include);


            return await query.SingleOrDefaultAsync(criteria);
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {

            IQueryable<T> query =  _context.Set<T>();
            // optinal get all includes(tabels in relation with entity)
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);


            return  await query.Where(criteria).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrdesrBy.Ascending)
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrdesrBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }
        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            
            return entity;
        }
        public async Task<IEnumerable<T>> AddRange(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            
            return entities;
        }
        public T  Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
