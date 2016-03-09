using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using RabbitMQ.Client;

namespace EEPA.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class TestMessageQueue
    {
        private const string QueueName = "hello2";

        [Test]
        public void TestMessageQueueIsRunning()
        {
            //---------------Set up test pack-------------------
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            
            var message = "Hello World!";
            var encodedMessage = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish("", QueueName, null, encodedMessage);
            Console.WriteLine(" [x] Sent '" + message + "'");
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            channel.Close();
            connection.Close();
            
        }
    }
}
