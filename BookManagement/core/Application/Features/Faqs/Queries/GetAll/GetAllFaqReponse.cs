using Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Faqs.Queries.GetAll
{
    public class GetAllFaqReponse
    {
        public string question { get; set; }
        public string answer { get; set; }
    }
}
