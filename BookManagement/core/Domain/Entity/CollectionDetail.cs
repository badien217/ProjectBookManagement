using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class CollectionDetail : Entitybase,IEntitybase
    {
        public int collectionId { get; set; }
        public Collection collection { get; set; }
        public int bookId { get; set; }
        public ICollection<Book> books { get; set;}
        public CollectionDetail() { }
        public CollectionDetail(int collectionId, Collection collection, int bookId, ICollection<Book> books)
        {
            this.collectionId = collectionId;
            this.collection = collection;
            this.bookId = bookId;
            this.books = books;
        }
    }
}
