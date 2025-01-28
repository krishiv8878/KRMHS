using KHRMS.Core;

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

        public async Task<bool> DeleteEmployee(long employeeId)
        {
            if (employeeId > 0)
            {
                var employeeDetails = await _unitOfWork.Employees.GetById(employeeId);
                if (employeeDetails != null)
                {
                    employeeDetails.IsDeleted = true;
                    employeeDetails.IsActive = false;

                    _unitOfWork.Employees.Update(employeeDetails);
                    var result = _unitOfWork.Save();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = await _unitOfWork.Employees.GetAll();
            return employees;
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            if (employeeId > 0)
            {
                var employeeDetails = await _unitOfWork.Employees.GetById(employeeId);
                if (employeeDetails != null)
                {
                    return employeeDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            if (employee != null)
            {
                var employeeDetails = await _unitOfWork.Employees.GetById(employee.Id);
                if (employeeDetails != null)
                {
                    employeeDetails.EmployeeCode=employee.EmployeeCode;
                    employeeDetails.FirstName = employee.FirstName;
                    employeeDetails.LastName = employee.LastName;
                    employeeDetails.EmailAddress = employee.EmailAddress;
                    employeeDetails.MobileNumber = employee.MobileNumber;
                    employeeDetails.DesignationId= employee.DesignationId;
                    employeeDetails.DateOfJoining= employee.DateOfJoining;
                    employeeDetails.Gender= employee.Gender;
                    employeeDetails.CurrentAddress= employee.CurrentAddress;
                    employeeDetails.PermanentAddress= employee.PermanentAddress;
                    employeeDetails.UpdatedDate = DateTime.Now;

                    _unitOfWork.Employees.Update(employeeDetails);
                    var result = _unitOfWork.Save();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
