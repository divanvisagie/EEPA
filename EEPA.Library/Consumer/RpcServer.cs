using System;
using System.Text;
using EEPA.Producer;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


namespace EEPA.Library.Consumer
{
    public class RpcServer
    {   
        public RpcServer()
        {
        }

        public void Listen<T>(string queueName, IRpcHandler handler)
        {   


            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                channel.BasicQos(0, 1, false);
                var consumer = new QueueingBasicConsumer(channel);
                channel.BasicConsume(queue: queueName,
                    noAck: false,
                    consumer: consumer);
                Console.WriteLine(" [x] Awaiting RPC requests");

                while (true)
                {
                    string response = null;
                    var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                    var body = ea.Body;
                    var props = ea.BasicProperties;
                    var replyProps = channel.CreateBasicProperties();
                    replyProps.CorrelationId = props.CorrelationId;

                    try
                    {
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [.] ({0})", message);
                        response = handler.HandleMessage(message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" [.] " + e.Message);
                        response = "";
                    }
                    finally
                    {
                        var responseBytes = Encoding.UTF8.GetBytes(response);
                        channel.BasicPublish(exchange: "",
                            routingKey: props.ReplyTo,
                            basicProperties: replyProps,
                            body: responseBytes);
                        channel.BasicAck(deliveryTag: ea.DeliveryTag,
                            multiple: false);
                    }
                }
            }
        }


   
    }
}