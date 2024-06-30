using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ratings.Command.Update
{
    public class UpdateCommandRatingRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string comment { get; set; }
        public float rating { get; set; }
        public int bookId { get; set; }
        public int userProfileId { get; set; }
    }
}
