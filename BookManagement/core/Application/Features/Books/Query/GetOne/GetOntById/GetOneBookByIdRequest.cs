using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Query.GetOne.GetOntById
{
    public class GetOneBookByIdRequest : IRequest<GetOneBookByIdReponse>
    {
        public int Id { get; set; }
    }
}
