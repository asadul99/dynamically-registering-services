using DynamicServiceRegistration.ServiceAttributes;

namespace DynamicServiceRegistration.Services
{
    [ScopedService]
    public class ScopedServiceNoInterface
    {
        public string GetServiceName()
        {
            return nameof(ScopedServiceNoInterface);
        }
    }
}
