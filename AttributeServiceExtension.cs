using DynamicServiceRegistration.ServiceAttributes;

using System.Reflection;

namespace DynamicServiceRegistration
{
    public static class AttributeServiceExtension
    {
        public static IServiceCollection RegisterServicesWithAttribute<TAttribute>(this IServiceCollection serviceCollection, Assembly assembly) where TAttribute : Attribute
        {
            var targetServices = assembly.GetTypes().Where(type => type.GetCustomAttribute<TAttribute>() != null);

            foreach (var serviceType in targetServices)
            {
                var attribute = serviceType.GetCustomAttribute<TAttribute>();
                ServiceLifetime lifetime = GetLifetimeFromAttribute(attribute);

                var implementdInterfaces = serviceType.GetInterfaces();
                //Class implemented interface
                if (implementdInterfaces != null && implementdInterfaces.Any())
                {
                    foreach (var @interface in implementdInterfaces)
                    {
                        RegisterService(serviceCollection, @interface, serviceType, lifetime);
                    }
                }
                else
                {
                    //Class doesn't implemented interface
                    RegisterService(serviceCollection, null, serviceType, lifetime);
                }
            }
            return serviceCollection;
        }
        private static IServiceCollection RegisterService(IServiceCollection serviceCollection, Type? @interface, Type serviceType, ServiceLifetime lifetime)
        {
            _ = lifetime switch
            {
                ServiceLifetime.Singleton => @interface != null ? serviceCollection.AddSingleton(@interface, serviceType) : serviceCollection.AddSingleton(serviceType),
                ServiceLifetime.Scoped => @interface != null ? serviceCollection.AddScoped(@interface, serviceType) : serviceCollection.AddScoped(serviceType),
                ServiceLifetime.Transient => @interface != null ? serviceCollection.AddTransient(@interface, serviceType) : serviceCollection.AddTransient(serviceType),
                _ => @interface != null ? serviceCollection.AddScoped(@interface, serviceType) : serviceCollection.AddScoped(serviceType),
            };
            return serviceCollection;
        }

        private static ServiceLifetime GetLifetimeFromAttribute(Attribute attribute)
        {
            if (attribute is ScopedService)
            {
                return ServiceLifetime.Scoped;
            }
            else if (attribute is SingletonService)
            {
                return ServiceLifetime.Singleton;
            }
            else if (attribute is TransientService)
            {
                return ServiceLifetime.Transient;
            }

            // Default to Scoped if the attribute type is unknown
            return ServiceLifetime.Scoped;
        }
    }
}
