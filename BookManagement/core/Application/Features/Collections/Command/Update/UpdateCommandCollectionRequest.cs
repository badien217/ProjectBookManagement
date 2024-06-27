using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Collections.Command.Update
{
    public class UpdateCommandCollectionRequest :IRequest<Unit>
    {

        public int Id { get; set; }
        public string name { get; set; }
        public string content { get; set; }

        public int saleId { get; set; }
    }
}
