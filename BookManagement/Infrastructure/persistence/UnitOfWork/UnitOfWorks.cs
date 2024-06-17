using Application.Interfaces.Reponsitories;
using Application.Interfaces.UnitOfWork;
using persistence.context;
using persistence.Reponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistence.UnitOfWork
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly AddDbContext _dbContext;
        public UnitOfWorks(AddDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async ValueTask DisposeAsync()=> await _dbContext.DisposeAsync();

        public int Save() => _dbContext.SaveChanges();
        

        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();


        IReadReponsitory<T> IUnitOfWork.GetReadReponsitory<T>() => new ReadReponsitory<T>(_dbContext);


        IWriteReponsitory<T> IUnitOfWork.GetWriteReponsitory<T>() => new WriteReponsitory<T>(_dbContext);
        
    }
}
