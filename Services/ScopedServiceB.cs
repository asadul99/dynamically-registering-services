using DynamicServiceRegistration.ServiceAttributes;

namespace DynamicServiceRegistration.Services
{
    [ScopedService]
    public class ScopedServiceB : IScopedServiceB
    {
        public string GetServiceName()
        {
            return nameof(ScopedServiceB);
        }
    }
}
