using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Rating : Entitybase,IEntitybase
    {
        public string comment { get; set; }
        public float rating { get; set; }
        public int bookId { get; set; }
        public Book book { get; set; }
        public int userProfileId { get; set; }  
        public UserProfile userProfile { get; set; }
        public Rating() { }
        public Rating(string comment, float rating, int bookId, Book book, int userProfileId, UserProfile userProfile)
        {
            this.comment = comment;
            this.rating = rating;
            this.bookId = bookId;
            this.book = book;
            this.userProfileId = userProfileId;
            this.userProfile = userProfile;
        }
    }
}
