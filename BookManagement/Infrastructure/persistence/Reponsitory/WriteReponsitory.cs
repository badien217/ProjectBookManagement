using Application.Interfaces.Reponsitories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using persistence.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistence.Reponsitory
{
    public class WriteReponsitory<T> : IWriteReponsitory<T> where T : class, IEntitybase, new()
    {
        public readonly AddDbContext addDbContext;
        public WriteReponsitory(AddDbContext addDbContext) { 
            this.addDbContext = addDbContext;
        }
        public DbSet<T> table { get => addDbContext.Set<T>(); }
        public async Task AddAsync(T entity)
        {

            await table.AddAsync(entity);
        }

        public async Task AddRangerAsync(IList<T> entities)
        {
            await table.AddRangeAsync(entities);
        }

        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => { table.Remove(entity); });
        }

        public async Task HardDeleteRangerAsync(IList<T> entity)
        {
            await Task.Run(() => { table.RemoveRange(entity); });
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => table.Update(entity));
            return entity;
        }
    }
}
