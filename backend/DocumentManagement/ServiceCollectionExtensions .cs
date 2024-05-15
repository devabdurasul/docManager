using DocumentManagement.Entities;
using DocumentManagement.Services;

namespace DocumentManagement
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTypeT<T>(this IServiceCollection services) where T : BaseEntity
        {
            services.AddTransient(typeof(IGenericService<T>), typeof(GenericService<T>));
            return services;
        }
    }
}
