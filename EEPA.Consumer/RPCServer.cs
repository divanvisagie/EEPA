using System;
using System.Text;
using EEPA.Library.Consumer;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EEPA.Consumer
{
    public class RpcServer
    {
        public static void Main()
        {
            new Listener().Listen<Fibonacci>("fibonacci", inMessage => new MathAnswer(Fib(inMessage.Number)));
        }


        /// <summary>
        /// Assumes only valid positive integer input.
        /// Don't expect this one to work for big numbers,
        /// and it's probably the slowest recursive implementation possible.
        /// </summary>
        private static int Fib(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            return Fib(n - 1) + Fib(n - 2);
        }
    }
}