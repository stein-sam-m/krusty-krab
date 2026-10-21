using System.Data;
using KrustyKrab.Domain.Employees;
using MySqlConnector;

namespace KrustyKrab.Infrastructure.Employees;

public sealed class EmployeeRepository(MySqlDataSource dataSource) : IEmployeeRepository
{
    public async Task<IReadOnlyList<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        await using var connection = await dataSource.OpenConnectionAsync(cancellationToken);
        using var command = new MySqlCommand("get_employees", connection)
        {
            CommandType = CommandType.StoredProcedure,
        };

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);

        var employees = new List<Employee>();
        while (await reader.ReadAsync(cancellationToken))
            employees.Add(ReadEmployee(reader));

        return employees;
    }

    public async Task<Employee?> GetByIdAsync(uint employeeId, CancellationToken cancellationToken = default)
    {
        await using var connection = await dataSource.OpenConnectionAsync(cancellationToken);
        using var command = new MySqlCommand("get_employee_by_id", connection)
        {
            CommandType = CommandType.StoredProcedure,
        };
        // Matched to the procedure's IN parameter by name, so it must be spelled the same.
        command.Parameters.AddWithValue("p_employee_id", employeeId);

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);

        return await reader.ReadAsync(cancellationToken) ? ReadEmployee(reader) : null;
    }

    private static Employee ReadEmployee(MySqlDataReader reader) => new(
        EmployeeId: reader.GetUInt32("employee_id"),
        FirstName: reader.GetString("first_name"),
        LastName: reader.GetString("last_name"),
        HourlyPay: reader.GetDecimal("hourly_pay"),
        HireDate: reader.GetDateOnly("hire_date"));
}
