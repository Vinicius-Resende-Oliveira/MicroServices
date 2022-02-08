using Newtonsoft.Json;
using Orders.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Orders.Comunication
{
    public class Publish
    {
        public void pubProduct()
        {
            Product product = new Product() { Id = 1, Nome = "Produto 1", Price = 10, Quantity = 10};
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ConfirmSelect();
                channel.BasicAcks += Evento_Confirmacao;
                channel.BasicNacks += Evento_NaoConfirmacao;

                channel.QueueDeclare(queue: "product",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var json = JsonConvert.SerializeObject(product);

                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "",
                    routingKey: "product",
                    basicProperties: null,
                    body: body);
            }
        }

        public void Evento_NaoConfirmacao(object sender, BasicNackEventArgs e)
        {
            Console.WriteLine("Nack");
        }
        public void Evento_Confirmacao(object sender, BasicAckEventArgs e)
        {
            Console.WriteLine("Ack");

        }
    }
}
