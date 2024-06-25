using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Command.Delete
{
    public class DeleteCommandAuthorRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
