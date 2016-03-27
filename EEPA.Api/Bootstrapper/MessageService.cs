using EEPA.Library.Client;
using EEPA.Producer;

namespace EEPA.Api.Bootstrapper
{
    public class MessageService : IMessageService
    {
        private readonly Client _client;

        public MessageService()
        {
            _client = new Client();
        }

        public string Send(string message)
        {
            return _client.Call(message);
        }

        public TR Send<T,TR>(IDomainMessage<T> domainMessage)
        {
            var messageResponse = _client.Call<T,TR>(domainMessage);
            return messageResponse;
        }
    }
}