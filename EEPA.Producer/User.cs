using Newtonsoft.Json;

namespace EEPA.Producer
{
    public class User : IDomainMessage<User>
    {
        public string UserName { get; set; }
    }

    public class AdminUser : User, IDomainMessage<AdminUser>
    {
        public bool Boss = true;
    }
}