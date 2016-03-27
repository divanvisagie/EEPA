using System;
using EEPA.Producer;
using Newtonsoft.Json;

namespace EEPA.Library.Consumer
{
    internal class RawHandler<T> : IRpcHandler
    {
        private readonly Func<T, IDomainMessage> _handler;
        public RawHandler(Func<T, IDomainMessage> handler)
        {
            _handler = handler;
        }

        public string HandleMessage(string message)
        {
            var inMessage = JsonConvert.DeserializeObject<T>(message);
            var msg = _handler(inMessage);
            return JsonConvert.SerializeObject(msg);
        }
    }
      

    public class Listener
    {
        public RpcServer Listen<T>(string queueName, Func<T, IDomainMessage> handler)
        {
            var server = new RpcServer();
            var rawHandler = new RawHandler<T>(handler);
            server.Listen<T>(queueName,rawHandler);
            return server;
        }
    }
}
