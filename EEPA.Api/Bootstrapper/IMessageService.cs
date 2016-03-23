using EEPA.Producer;

namespace EEPA.Api.Bootstrapper
{
    public interface IMessageService
    {
        string Send(string message);
        string Send<T>(IDomainMessage<T> domainMessage);
        string Send<T>(IDomainMessage message);
    }
}