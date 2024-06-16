using Application.Interfaces.Reponsitories;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadReponsitory<T> GetReadReponsitory<T>() where T : class, IEntitybase, new();
        IWriteReponsitory<T> GetWriteReponsitory<T>() where T : class, IEntitybase, new();
        Task<int> SaveAsync();
        int Save();
    }
}
