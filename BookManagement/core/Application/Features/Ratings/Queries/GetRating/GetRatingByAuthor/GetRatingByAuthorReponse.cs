using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ratings.Queries.GetRating.GetRatingByAuthor
{
    public class GetRatingByAuthorReponse
    {  
        public string comment { get; set; }
        public int rating { get; set; }
        public BookDtos Book { get; set; }
        public AuthorDtos Author { get; set; }
       
        
    }
}
