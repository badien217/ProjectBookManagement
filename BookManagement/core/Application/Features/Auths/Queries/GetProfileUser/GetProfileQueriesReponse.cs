﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Queries.GetProfileUser
{
    public class GetProfileQueriesReponse
    {
        public string Phone { get; set; }
        public string subscriptionType { get; set; }

        public string paymentOption { get; set; }
        public string paymentStatus { get; set; }
        public string avatar { get; set; }
    }
}
