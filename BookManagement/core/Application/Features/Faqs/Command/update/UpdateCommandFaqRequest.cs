﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Faqs.Command.update
{
    public class UpdateCommandFaqRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
    }
}
