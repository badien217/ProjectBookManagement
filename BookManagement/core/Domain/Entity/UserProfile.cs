using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class UserProfile:Entitybase,IEntitybase
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Phone { get; set; }
        public string subscriptionType { get; set; }
        public string paymentOption { get; set; }
        public string paymentStatus { get; set; }
        public string avatar { get; set; }
        public User user { get; set; }
    }
}
