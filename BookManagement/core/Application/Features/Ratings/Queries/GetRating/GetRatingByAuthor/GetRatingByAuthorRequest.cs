using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ratings.Queries.GetRating.GetRatingByAuthor
{
    public class GetRatingByAuthorRequest : IRequest<GetRatingByAuthorReponse>
    {
        public int IdAuthor { get; set; }
    }
}
