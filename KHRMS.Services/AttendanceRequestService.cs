using KHRMS.Core;


namespace KHRMS.Services
{
    public class AttendanceRequestService(IUnitOfWork unitOfWork) : IAttendanceRequestService
    {
        public IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<AttendanceRequest>> GetAllAsync()
        {
            var attendanceRequests = await _unitOfWork.AttendanceRequests.GetAll();
            return attendanceRequests;
        }

        public async Task<AttendanceRequest> GetByIdAsync(long id)
        {
            var attendanceRequests = await _unitOfWork.AttendanceRequests.GetById(id);
            return attendanceRequests;
        }

        public async Task AddAsync(AttendanceRequest attendanceRequest)
        {
            await _unitOfWork.AttendanceRequests.Add(attendanceRequest);
            var result = _unitOfWork.Save();

        }

        public Task UpdateAsync(AttendanceRequest attendanceRequest)
        {
            _unitOfWork.AttendanceRequests.Update(attendanceRequest);
            var result = _unitOfWork.Save();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(long id)
        {
            _unitOfWork.AttendanceRequests.DeleteAsync(id);
            var result = _unitOfWork.Save();
            return Task.CompletedTask;
        }
    }
}





