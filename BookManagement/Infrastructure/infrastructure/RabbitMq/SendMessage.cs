using Application.Interfaces.SendMessages;
using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.RabbitMq
{
    public class SendMessage : ISendMessageRabbitMQ
    {
         void ISendMessageRabbitMQ.SendMessages<T>(T message)
        {
            ConnectionFactory factory = new ConnectionFactory();


            factory.HostName = "localhost";
            factory.Port = 5672;
            factory.UserName = "admin";
            factory.Password = "badien217";

            factory.VirtualHost = "/";

            var con = factory.CreateConnection();
            using var channel = con.CreateModel();
            channel.QueueDeclare("order", durable: true, exclusive: false);
            var jsonString = System.Text.Json.JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);
            channel.BasicPublish("", "order", body: body);


        }
    }
}
