using EEPA.Producer;

namespace EEPA.Api.Bootstrapper
{
    public class MessageService : IMessageService
    {
        private RpcClient _rpcClient;

        public MessageService()
        {
            _rpcClient = new RpcClient();
        }

        public string Send(string message)
        {
            return _rpcClient.Call(message);
        }

        public string Send<T>(IDomainMessage<T> domainMessage)
        {
            var messageResponse = _rpcClient.Call<T>(domainMessage);
            return messageResponse;
        }

        public string Send<T>(IDomainMessage domainMessage)
        {
            var messageResponse = _rpcClient.Call<T>(domainMessage);
            return messageResponse;
        }
    }
}