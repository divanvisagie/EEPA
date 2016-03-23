using System.Security.Cryptography.X509Certificates;

namespace EEPA.Producer
{
    public interface IDomainMessage
    {
        
    }

    public interface IDomainMessage<T> : IDomainMessage
    {
        
    }
}