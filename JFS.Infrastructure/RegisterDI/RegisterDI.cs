using System.Reflection;
using JFS.Application.Helper;
using JFS.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JFS.Infrastructure
{
    public static class RegisterDI
    {
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<SqlServerDbContext>(p => p.UseSqlServer(configuration.GetConnectionString("sqlserver")));
        }
    }
}
