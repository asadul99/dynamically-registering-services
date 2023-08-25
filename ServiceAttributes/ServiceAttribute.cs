namespace DynamicServiceRegistration.ServiceAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SingletonService : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ScopedService : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class TransientService : Attribute
    {
    }
}