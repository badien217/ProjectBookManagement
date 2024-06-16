using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Rating
    {
        public string comment { get; set; }
        public float rating { get; set; }
        public int bookId { get; set; }
        public Book book { get; set; }
        public UserProfile userProfile { get; set; }
        public Rating() { }
        public Rating(string comment, float rating, int bookId, Book book, UserProfile userProfile)
        {
            this.comment = comment;
            this.rating = rating;
            this.bookId = bookId;
            this.book = book;
            this.userProfile = userProfile;
        }
    }
}
