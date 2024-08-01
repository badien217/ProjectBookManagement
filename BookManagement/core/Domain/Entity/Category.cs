using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Category : Entitybase,IEntitybase
    {
        public string name { get;set; }
        public string image { get; set; }
        public ICollection<Product> product { get; set; }
    }
}
