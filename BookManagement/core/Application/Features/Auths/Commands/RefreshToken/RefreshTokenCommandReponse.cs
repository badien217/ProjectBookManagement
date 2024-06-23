using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.RefreshToken
{
    public class RefreshTokenCommandReponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
