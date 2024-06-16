using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Reponsitories
{
    public interface IWriteReponsitory<T>where T : class,IEntitybase,new ()
    {
        Task AddAsync(T entity);//add
        Task AddRangerAsync(IList<T> entities);//add 1 danh sach
        Task HardDeleteAsync(T entity);//xóa 
        Task<T> UpdateAsync(T entity);// update 
        Task HardDeleteRangerAsync(IList<T> entity);//xóa 1 danh sách liên quan
    }
}
