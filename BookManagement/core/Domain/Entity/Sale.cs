using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Sale : Entitybase,IEntitybase
    {
        public string name { get; set; }
        public string description { get; set; }
        public long percentageSale { get; set; }
        public DateTime endDate { get; set; }
        public Sale() { }
        public Sale(string name, string description, long percentageSale, DateTime endDate)
        {
            this.name = name;
            this.description = description;
            this.percentageSale = percentageSale;
            this.endDate = endDate;
        }
    }
}
