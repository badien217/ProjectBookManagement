using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Product : Entitybase,IEntitybase
    {
        public string name { get; set; }
        public string description { get; set; }
        public float sellingPrice { get; set; }
        public float mrp { get; set; }
        public int itemQuantityType { get; set; }
    }
}
