using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Query.GetOne.GetOneByAuthor
{
    public class GetOneBookByAuthorRequest : IRequest<IList<GetOneBookByAuthorReponse>>
    {
        public int AuthorId { get; set; }
    }
}
