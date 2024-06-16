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
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string filePDF { get; set; }
        public Book() { }
        public Book(string title, string author, string imageUrl, decimal price, int quantity, string filePDF)
        {
            Title = title;
            Author = author;
            ImageUrl = imageUrl;
            Price = price;
            Quantity = quantity;
            this.filePDF = filePDF;
        }
    }
}
