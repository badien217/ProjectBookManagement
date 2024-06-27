using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Collections.Queries.GetAll
{
    public class GetAllQueriesCollectionRequest : IRequest<IList<GetAllQueriesCollectionReponse>>
    {
    }
}
