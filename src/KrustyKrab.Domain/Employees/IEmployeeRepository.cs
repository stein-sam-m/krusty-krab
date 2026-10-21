namespace KrustyKrab.Domain.Employees;

public interface IEmployeeRepository
{
    Task<IReadOnlyList<Employee>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <returns>The employee, or null if no employee has that id.</returns>
    Task<Employee?> GetByIdAsync(uint employeeId, CancellationToken cancellationToken = default);
}
