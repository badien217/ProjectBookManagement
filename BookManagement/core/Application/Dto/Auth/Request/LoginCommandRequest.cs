using Application.Dto.Auth.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Auth.Request
{
    public class LoginCommandRequest : IRequest<LoginCommandReponse>
    {
        [DefaultValue("badien21720004@gmail.com")]
        public string Email { get; set; }
        [DefaultValue("string")]
        public string Password { get; set; }
    }
}
