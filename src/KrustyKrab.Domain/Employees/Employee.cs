namespace KrustyKrab.Domain.Employees;

public sealed record Employee(
    uint EmployeeId,
    string FirstName,
    string LastName,
    decimal HourlyPay,
    DateOnly HireDate);
