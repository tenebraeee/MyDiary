using Core.Db.Contexts;
using EntityFrameworkCore.UnitOfWork.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Db
{
    public static class Injection
    {
        public static IServiceCollection RegisterDb(
                this IServiceCollection services
            )
        {
            services.AddDbContext<SqlContext>();

            services.AddScoped<DbContext, SqlContext>();
            services.AddUnitOfWork();

            return services;
        }

        public static void MigrateDb(this IServiceProvider provider)
        {
            var factory = provider.GetRequiredService<IServiceScopeFactory>();
            using var scope = factory.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<DbContext>();

            context.Database.Migrate();
        }
    }
}
