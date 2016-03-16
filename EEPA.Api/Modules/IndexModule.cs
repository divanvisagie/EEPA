using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEPA.Api.Bootstrapper;
using Nancy;

namespace EEPA.Api.Modules
{
    public class IndexModule : NancyModule
    {
        private readonly IMessageService _messageService;

        public IndexModule(IMessageService messageService) : base("/api")
        {
            _messageService = messageService;

            Get["/"] = Index;
            Post["/message/{message}"] = SendMessage;
        }

        private dynamic SendMessage(dynamic o)
        {
            string message = o.message;
            var response = _messageService.Send(message);
            return response;
        }

        private dynamic Index(dynamic o)
        {
            return "Api is running";
        }
    }
}
