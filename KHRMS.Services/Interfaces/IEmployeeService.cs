using KHRMS.Core.Models;

namespace KHRMS.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> CreateEmployee(Employee employee);
    }
}
