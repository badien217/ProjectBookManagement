﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Profile.DeleteProfile
{
    public class DeleteProfileCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
