using KHRMS.Core;
using KHRMS.Core.Models;
using KHRMS.Services.Interfaces;

namespace KHRMS.Services
{
    public class EmployeeService(IUnitOfWork unitOfWork) : IEmployeeService
    {
        public IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> CreateEmployee(Employee employee)
        {
            if (employee != null)
            {
             
                await _unitOfWork.Employees.Add(employee);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
