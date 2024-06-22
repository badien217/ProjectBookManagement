using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Profile.UpdateInfo.UpdateProfileUser
{
    public class UpdateProfileUserRequest : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public string Phone { get; set; }
        public string subscriptionType { get; set; }
        public string paymentOption { get; set; }
        public string paymentStatus { get; set; }
        public IFormFile avatar { get; set; }
    }
}
