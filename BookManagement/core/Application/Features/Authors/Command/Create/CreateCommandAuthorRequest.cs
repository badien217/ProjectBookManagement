using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Command.Create
{
    public class CreateCommandAuthorRequest : IRequest<Unit>
    {
        public string name { get; set; }

        public string age { get; set; }
        public float rating { get; set; }
        public string avatar { get; set; }
    }
}
