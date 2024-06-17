using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class OrderDetail : Entitybase,IEntitybase
    {
        public int OrderId { get; set; }

        public Order orders { get; set; }
        public int BookId { get; set; }
        public ICollection<Book> Books { get; set; }
        public int Quatity { get; set; }
        public OrderDetail() { }
        public OrderDetail(int orderId, Order orders, int bookId, ICollection<Book> books, int quatity)
        {
            OrderId = orderId;
            this.orders = orders;
            BookId = bookId;
            Books = books;
            Quatity = quatity;
        }
    }
}
