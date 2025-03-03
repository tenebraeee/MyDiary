using EntityFrameworkCore.UnitOfWork.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyDiary.Db.Contexts;

namespace MyDiary.Db
{
    public static class Injection
    {
        public static IServiceCollection RegisterDb(
                this IServiceCollection services,
                     string connectionString
            )
        {
            services.AddDbContext<SqlContext>(o =>
                 {
                     o.UseSqlite(connectionString);
                 });

            services.AddScoped<DbContext, SqlContext>();
            services.AddUnitOfWork();

            return services;
        }
    }
}
