using Application.Interfaces.Reponsitories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using persistence.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace persistence.Reponsitory
{
    public class ReadReponsitory<T> : IReadReponsitory<T> where T : class, IEntitybase, new()
    {
        private readonly AddDbContext _dbContext;
        public ReadReponsitory(AddDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        private DbSet<T> table { get => _dbContext.Set<T>(); }
        public Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            table.AsNoTracking();
            if(predicate != null) { table.Where(predicate); }
            return table.CountAsync();
        }

        public async Task<IQueryable<T>> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
        {
            if (!enableTracking) table.AsNoTracking();
            return table.Where(predicate);
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> queryTable = table;
            if (!enableTracking)
            {
                queryTable = queryTable.AsNoTracking();// asnotracking will query data with no codition 
            }
            if (include is not null) { queryTable = include(queryTable); }// nếu có thêm thực thể để query ra thì thêm include
            if (predicate is not null) { queryTable = queryTable.Where(predicate); } // nếu có điều kiện để thì sẽ where
            if (orderBy is not null) { return await orderBy(queryTable).ToListAsync(); }// nếu muốn sắp xếp thì gọi orderby
            return await queryTable.ToListAsync();// trả về querytable
        }

        public async Task<IList<T>> GetAllAsyncPacing(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int curentPage = 1, int pageSize = 5)
        {
            IQueryable<T> queryTable = table;
            if (!enableTracking)
            {
                queryTable = queryTable.AsNoTracking();

            }
            if (include is not null) { queryTable = include(queryTable); }
            if (predicate is not null) { queryTable = queryTable.Where(predicate); }
            if (orderBy is not null)
            {
                return await orderBy(queryTable)
                    .Skip((curentPage - 1) * pageSize)// skip từ vị trí
                    .Take(pageSize).ToListAsync();
            }
            return await queryTable.Skip((curentPage - 1) * pageSize)
                    .Take(pageSize).ToListAsync(); ;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryTable = table;
            if (!enableTracking)
            {
                queryTable = queryTable.AsNoTracking();

            }
            if (include is not null) { queryTable = include(queryTable); }
            return await queryTable.FirstOrDefaultAsync(predicate);
        }
    }
}
