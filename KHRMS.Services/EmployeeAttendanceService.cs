using KHRMS.Core;

namespace KHRMS.Services
{

    public class EmployeeAttendanceService(IUnitOfWork unitOfWork) : IEmployeeAttendanceService
    {
        public IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<EmployeeAttendance>> GetAllAsync()
        {
            return await _unitOfWork.EmployeeAttendance.GetAll();
        }

        public async Task<EmployeeAttendance> GetByIdAsync(long id)
        {
            return await _unitOfWork.EmployeeAttendance.GetById(id);
        }

        public async Task<EmployeeAttendance> GetByEmployeeIdAsync(long employeeId)
        {
            return await _unitOfWork.EmployeeAttendance.GetByEmployeeIdAsync(employeeId);

        }

        public async Task AddAsync(EmployeeAttendance attendance)
        {
            await _unitOfWork.EmployeeAttendance.Add(attendance);
            var result = _unitOfWork.Save();

        }

        public Task UpdateAsync(EmployeeAttendance attendance)
        {
            _unitOfWork.EmployeeAttendance.Update(attendance);
            var result = _unitOfWork.Save();
            return Task.CompletedTask;
        }

        public  Task DeleteAsync(long id)
        {
            _unitOfWork.EmployeeAttendance.DeleteAsync(id);
            var result = _unitOfWork.Save();
            return Task.CompletedTask;

        }
       
    }
}


