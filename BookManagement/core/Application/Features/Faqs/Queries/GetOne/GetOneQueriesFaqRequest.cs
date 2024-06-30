using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Faqs.Queries.GetOne
{
    public class GetOneQueriesFaqRequest : IRequest<GetOneQueriesFaqReponse>
    {
        public int Id { get; set; }
    }
}
