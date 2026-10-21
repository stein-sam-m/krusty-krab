using KrustyKrab.Domain.Employees;
using KrustyKrab.Infrastructure.Employees;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace KrustyKrab.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        // MySqlDataSource pools connections; one shared instance for the app's lifetime.
        services.AddSingleton(new MySqlDataSource(connectionString));
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        return services;
    }
}
