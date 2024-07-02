using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.SendMessages
{
    public interface ISendMessageRabbitMQ
    {
        void SendMessages<T>(T message);
    }
}
