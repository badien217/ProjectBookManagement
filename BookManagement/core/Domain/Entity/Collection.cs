using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Collection : Entitybase,IEntitybase
    {
        public string name { get; set;}
        public string content { get; set;}

        public int bookId { get; set;}
        public Book book { get; set; }
        public int saleId { get; set;}
        public Sale sale { get; set;}
        public Collection() { }
        public Collection(string name, string content, int bookId, Book book, int saleId, Sale sale)
        {
            this.name = name;
            this.content = content;
            this.bookId = bookId;
            this.book = book;
            this.saleId = saleId;
            this.sale = sale;
        }
    }
}
