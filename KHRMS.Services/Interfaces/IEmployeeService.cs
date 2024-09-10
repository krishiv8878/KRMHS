using KHRMS.Core;

namespace KHRMS.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> CreateEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int employeeId);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(long employeeId);
    }
}
