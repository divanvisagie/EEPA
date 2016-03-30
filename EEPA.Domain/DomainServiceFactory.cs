using System.Linq;
using TinyIoC;

namespace EEPA.Domain
{
    public class DomainServiceFactory : IDomainServiceFactory   
    {
        private readonly TinyIoCContainer _tinyIoCContainer;

        public DomainServiceFactory(TinyIoCContainer tinyIoCContainer)
        {
            _tinyIoCContainer = tinyIoCContainer;
        }

        public DomainServiceFactory()
        {
            _tinyIoCContainer = new TinyIoCContainer();
        }

        public IDomainService Create<T>() where T : IDomainService
        {
            //var instance = (IDomainService)Activator.CreateInstance(typeof(T));
            var constructorInfos = typeof(T).GetConstructors();
            
            //ignore other constructors
            var defaultConstructor = constructorInfos[0];
            var parameterInfos = defaultConstructor.GetParameters().ToList();
            

            var instanceArgs = parameterInfos.Select(p => _tinyIoCContainer.Resolve(p.ParameterType)).ToArray();
            var invoke = (IDomainService) defaultConstructor.Invoke(instanceArgs);
            return invoke;
            //return (IDomainService) Activator.CreateInstance(typeof(T), instanceArgs);
        }
    }
}