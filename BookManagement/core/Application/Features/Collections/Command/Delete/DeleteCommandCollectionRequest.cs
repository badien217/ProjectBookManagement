using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Collections.Command.Delete
{
    public class DeleteCommandCollectionRequest : IRequest<Unit>
    {
        public int Id { get; set; } 
    }
}
