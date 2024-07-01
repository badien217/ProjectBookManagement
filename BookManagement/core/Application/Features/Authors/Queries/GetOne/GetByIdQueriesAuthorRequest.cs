﻿using Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Queries.GetOne
{
    public class GetByIdQueriesAuthorRequest : IRequest<GetByIdQueriesAuthorReponse>
    {
        public int Id { get; set; }
    }
}
