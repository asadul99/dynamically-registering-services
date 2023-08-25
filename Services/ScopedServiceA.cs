using DynamicServiceRegistration.ServiceAttributes;

namespace DynamicServiceRegistration.Services
{
    [ScopedService]
    public class ScopedServiceA : IScopedServiceA
    {
        public string GetServiceName()
        {
            return nameof(ScopedServiceA);
        }
    }
}
