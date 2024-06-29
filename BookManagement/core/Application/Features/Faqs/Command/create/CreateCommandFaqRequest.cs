using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Faqs.Command.create
{
    public class CreateCommandFaqRequest : IRequest<Unit>
    {
        public string question { get; set; }
        public string answer { get; set; }
    }
}
