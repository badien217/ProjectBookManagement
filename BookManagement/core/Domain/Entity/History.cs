using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class History : Entitybase,IEntitybase
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        
        public string Status { get; set; }
        public string Localtion { get; set; }
        public string Comments { get; set; }
        public History() { }
        public History(int orderId,Order order,string status,string localtion,string comments)
        {
            OrderId = orderId;
            Order = order;
            Status = status;
            Localtion = localtion;
            Comments = comments;
        }
        

         
    }
}
