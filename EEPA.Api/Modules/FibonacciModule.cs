using EEPA.Api.Bootstrapper;
using Nancy;

namespace EEPA.Api.Modules
{
    public class FibonacciModule : NancyModule
    {
        private readonly IMessageService _messageService;

        public FibonacciModule(IMessageService messageService)
            : base("/api")
        {
            _messageService = messageService;

            Post["/fibonacci/{message}"] = SendFibonacci;
        }

        private dynamic SendFibonacci(dynamic o)
        {
            string message = o.message;
            var response = _messageService.Send(message);
            return response;
        }
    }
}