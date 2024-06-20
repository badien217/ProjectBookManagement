using Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Exceptions
{
    public class UserAlreadyExistException : BaseException
    {
        public UserAlreadyExistException():base("tài khoản đã tồn tại") { }
    }
}
