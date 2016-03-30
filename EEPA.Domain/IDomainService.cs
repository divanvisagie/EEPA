namespace EEPA.Domain
{
    public interface IDomainService
    {
        string HandleQuery();
        IDomainDriver DomainDriver { get; set; }
    }
}