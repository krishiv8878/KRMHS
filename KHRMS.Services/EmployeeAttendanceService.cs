using KHRMS.Core;
using System.Reflection.Metadata;

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

        public async Task DeleteAsync(long id)
        {
            var attendance = await _unitOfWork.EmployeeAttendance.GetById(id);          
            if (attendance != null)
            {
                _unitOfWork.EmployeeAttendance.Delete(attendance);
                _unitOfWork.Save();
            }


        }
      

    }
}


