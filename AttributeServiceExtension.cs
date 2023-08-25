using System.Reflection;

namespace DynamicServiceRegistration
{
    public static class AttributeServiceExtension
    {
        public static IServiceCollection RegisterOfType<TAttribute>(this IServiceCollection serviceCollection, Assembly assembly, ServiceLifetime lifetime) where TAttribute : Attribute
        {
            var targetServices = assembly.GetTypes().Where(type => type.GetCustomAttribute<TAttribute>() != null);

            foreach (var serviceType in targetServices)
            {
                var implementdInterfaces = serviceType.GetInterfaces();
                if (implementdInterfaces != null && implementdInterfaces.Any())
                {
                    foreach (var @interface in implementdInterfaces)
                    {
                        RegisterService(serviceCollection, @interface, serviceType, lifetime);
                    }
                }
                else
                {
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
    }
}
