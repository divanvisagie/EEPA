namespace EEPA.Domain
{
    public interface IDomainServiceFactory
    {
        IDomainService Create<T>() where T : IDomainService;
    }
}