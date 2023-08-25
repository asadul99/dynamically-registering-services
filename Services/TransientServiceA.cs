using DynamicServiceRegistration.ServiceAttributes;

namespace DynamicServiceRegistration.Services
{
    [TransientService]
    public class TransientServiceA : ITransientServiceA
    {
        public string GetServiceName()
        {
            return nameof(TransientServiceA);
        }
    }
}
