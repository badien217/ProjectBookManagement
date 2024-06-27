using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Collections.Queries.GetAll
{
    public class GetAllQueriesCollectionReponse
    {
        public string name { get; set; }
        public string content { get; set; }
        public SaleDtos SaleDtos { get; set; }
    }
}
