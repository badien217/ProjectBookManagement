using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Profile.UpdateInfo.ChangePass
{
    public class ChangePasswordRequest : IRequest<Unit>
    {
        public string email { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
