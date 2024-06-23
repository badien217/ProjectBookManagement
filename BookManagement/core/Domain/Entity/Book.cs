using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Book :Entitybase ,IEntitybase
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string filePDF { get; set; }
        public int AuthorId { get;set; }
        public Author author { get; set; }

    
        public Book() { }
        public Book(string title, string imageUrl, decimal price, int quantity, string filePDF, int authorId, Author author)
        {
            Title = title;
            ImageUrl = imageUrl;
            Price = price;
            Quantity = quantity;
            this.filePDF = filePDF;
            AuthorId = authorId;
            this.author = author;

        }
    }
}
