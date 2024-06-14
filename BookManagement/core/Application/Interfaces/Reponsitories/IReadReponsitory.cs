using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Interfaces.Reponsitories
{
    public interface IReadReponsitory<T> where T : class,IEntitybase,new()
    {
        //GetAllAsync
        // hàm get all để get ra danh sách đối tượng với những yêu cầu của người dùng như ,điều kiện lọc ,nạp đối tượng để get ra đầy đủ nhất và nhưng thông 
        // tin liên quan đến người dùng
        //hàm sắp xếp 
        //enableTracking để theo dõi quá trình thay đổi của hàm
        //
        Task<IList<T>> GetAllAsync(
        Expression<Func<T,bool>>? predicate = null,// điệu kiện lọc để là null
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,//dùng để nạp các thực thể ,sao cho có thể get ra những thông tin liên quan
                                                                             //cụ thể với đối dượng đó 
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,//sắp xếp đặt bằng null
        bool enableTracking = false// theo dỗi sự thay đổi
        );

        //GetAllAsyncPacing hàm này là phiên bản năng cấp của GetAll với khả năng phân trang

        Task<IList<T>> GetAllAsyncPacing(Expression<Func<T, bool>> predicate = null,//điều kiện lọc

           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,//nạp đối tượng 
           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,//hàm sắp xếp
           bool enableTracking = false, int curentPage = 1, int pageSize = 5);//số trang hiên tại và số lượng đối tượng trên mỗi trang
        // getAsync tương tự như get All nhung kiểu trả về là 1 đối tượng chứ không phải là 1 danh sách
        Task<T> GetAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false);
        // find trả về 1 tập hợp các danh sach truy vấn
        //khác với getAsync thì Find trả về 1 danh sách còn GetAsyncs trả về 1 đối tượng
        Task<IQueryable<T>> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

    }
}
