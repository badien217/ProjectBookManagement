using Application.Base;
using Application.Features.Auths.Exceptions;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Rules
{
    public class AuthRule : BaseRule
    {
        public Task UserShouldNotExist(User? user) {
            if(user is not null ) throw new UserAlreadyExistException(); return Task.CompletedTask;
        }
        public Task EmailOrPasswordShouldNotBeInvalid(User? user , bool checkPassWord) {
            if (user is null || !checkPassWord) throw new EmailOrPasswordShouldNotBeInvalidException(); return Task.CompletedTask;
        }
        public Task checkAccount(bool check)
        {
            if (check == true) throw new AccountNotFound();
            return Task.CompletedTask;
        }
        public Task RefreshTokenShouldNotBeExpired(DateTime? expiryDate)
        {
            if (expiryDate <= DateTime.Now) throw new RefreshTokenShouldNotBeExpiredException();
            return Task.CompletedTask;
        }
        public Task EmailAddressShouldBeValid(User? user)
        {
            if (user is null) throw new EmailAddressShouldBeValidException();
            return Task.CompletedTask;
        }
    }
}
    