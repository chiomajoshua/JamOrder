using JamOrder.Data.Persistence;
using MicroOrm.Dapper.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace JamOrder.Data.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection RegisterDatabaseService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            serviceCollection.AddDbContext<JamOrderDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("JamOrder.Data")));


            //Register Dapper
            serviceCollection.AddTransient<IDbConnection>(prov => new SqlConnection(connectionString));
            serviceCollection.AddTransient(typeof(DapperRepository<>));
            return serviceCollection;
        }
    }
}