namespace DynamicServiceRegistration.ServiceAttributes
{
    public interface ILifetimeAttribute
    {
        ServiceLifetime Lifetime { get; }
    }
}
