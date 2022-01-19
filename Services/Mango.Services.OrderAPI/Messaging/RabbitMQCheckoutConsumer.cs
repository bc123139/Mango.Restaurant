using Mango.Services.OrderAPI.Messages;
using Mango.Services.OrderAPI.RabbitMQSender;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mango.Services.OrderAPI.Messaging
{
    public class RabbitMQCheckoutConsumer : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IRabbitMQOrderMessageSender _rabbitMQOrderMessageSender;

        public RabbitMQCheckoutConsumer(IRabbitMQOrderMessageSender rabbitMQOrderMessageSender)
        {
            _rabbitMQOrderMessageSender = rabbitMQOrderMessageSender;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "checkoutqueue", false, false, false, arguments: null);
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            //Standard Queue Example::::::::::::::::::::::
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                CheckoutHeaderDto checkoutHeaderDto = JsonConvert.DeserializeObject<CheckoutHeaderDto>(content);
                HandleMessage(checkoutHeaderDto);//.GetAwaiter().GetResult();

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume("checkoutqueue", false, consumer);

            return Task.CompletedTask;
        }

        private  void HandleMessage(CheckoutHeaderDto checkoutHeaderDto)
        {
            Console.WriteLine(checkoutHeaderDto.FirstName);
            PaymentRequestMessage paymentRequestMessage = new()
            {
                Name = checkoutHeaderDto.FirstName + " " + checkoutHeaderDto.LastName,
                CardNumber = checkoutHeaderDto.CardNumber,
                CVV = checkoutHeaderDto.CVV,
                ExpiryMonthYear = checkoutHeaderDto.ExpiryMonthYear,
                OrderId = checkoutHeaderDto.Id,
                OrderTotal = checkoutHeaderDto.OrderTotal,
                Email = checkoutHeaderDto.Email
            };
            _rabbitMQOrderMessageSender.SendMessage(paymentRequestMessage, "orderpaymentprocessqueue");
            return;
        }
    }
}
