using Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalidException :BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException():base("tên người dùng hoặc mật khẩu không hợp lệ") { }
    }
}
