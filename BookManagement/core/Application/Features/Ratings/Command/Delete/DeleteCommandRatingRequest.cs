using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ratings.Command.Delete
{
    public class DeleteCommandRatingRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
