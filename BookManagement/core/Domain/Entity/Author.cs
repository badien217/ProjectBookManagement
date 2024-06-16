using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Author : Entitybase,IEntitybase
    {
        public string name { get; set; }
        public ICollection<Book> book { get; set; }
        public string age { get; set; }
        public float rating { get; set; }
        public string avatar { get; set; }
        public Author() { }
        public Author(string name, ICollection<Book> book, string age, float rating, string avatar)
        {
            this.name = name;
            this.book = book;
            this.age = age;
            this.rating = rating;
            this.avatar = avatar;
        }
    }
}
