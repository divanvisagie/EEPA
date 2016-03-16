using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEPA.Producer;
using Nancy;
using Nancy.TinyIoc;

namespace EEPA.Api.Bootstrapper
{
    public class CoreBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<IMessageService>(new MessageService());
        }
    }

    public class MessageService : IMessageService
    {
        public string Send(string message)
        {
            var rpcClient = new RpcClient();
            return rpcClient.Call(message);
        }
    }

    public interface IMessageService
    {
        string Send(string message);
    }
}
