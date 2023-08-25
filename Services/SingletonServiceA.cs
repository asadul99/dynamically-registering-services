using DynamicServiceRegistration.ServiceAttributes;

namespace DynamicServiceRegistration.Services
{
    [SingletonService]
    public class SingletonServiceA : ISingleTonServiceA
    {
        public string GetServiceName()
        {
            return nameof(SingletonServiceA);
        }
    }
}
