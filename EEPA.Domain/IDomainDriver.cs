using System;

namespace EEPA.Domain
{
    public interface IDomainDriver
    {
        void AttachToSystem(Type type);
    }
}