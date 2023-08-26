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

                var implementedInterfaces = serviceType.GetInterfaces();
                //Class implemented interface
                if (implementedInterfaces != null && implementedInterfaces.Any())
                {
                    foreach (var @interface in implementedInterfaces)
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
            // Adjust this based on how you retrieve lifetime information from the attribute
            // For example, if the attribute has a property named "Lifetime", you might use:
            // return ((YourAttributeType)attribute).Lifetime;

            // For now, let's assume the attribute has a property named "Lifetime" of type ServiceLifetime
            return (attribute as ILifetimeAttribute)?.Lifetime ?? ServiceLifetime.Scoped;
        }
    }
}
