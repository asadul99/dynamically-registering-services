namespace DynamicServiceRegistration.ServiceAttributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class SingletonServiceAttribute : Attribute, ILifetimeAttribute
    {
        public ServiceLifetime Lifetime => ServiceLifetime.Singleton;
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class ScopedServiceAttribute : Attribute, ILifetimeAttribute
    {
        public ServiceLifetime Lifetime => ServiceLifetime.Scoped;
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class TransientServiceAttribute : Attribute, ILifetimeAttribute
    {
        public ServiceLifetime Lifetime => ServiceLifetime.Transient;
    }
}