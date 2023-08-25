using DynamicServiceRegistration.ServiceAttributes;

namespace DynamicServiceRegistration.Services
{
    [ScopedService]
    public class ScopedServiceStandalone
    {
        public string GetServiceName()
        {
            return nameof(ScopedServiceStandalone);
        }
    }
}
