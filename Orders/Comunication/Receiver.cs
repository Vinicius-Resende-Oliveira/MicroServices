using Orders.Models;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Orders.Comunication
{
    public class Receiver
    {
        public Order rec()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "order",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var data = channel.BasicGet("order", true);

                    var json = Encoding.UTF8.GetString(data.Body.ToArray());

                    Order obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Order>(json);

                    return obj;
                }
            }
        }
    }
}
