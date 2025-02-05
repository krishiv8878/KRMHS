using KHRMS.Core;

namespace KHRMS.Services
{
    public interface IAttendanceRequestService
    {
        Task<IEnumerable<AttendanceRequest>> GetAllAsync();
        Task<AttendanceRequest> GetByIdAsync(long id);
        Task AddAsync(AttendanceRequest attendanceRequest);
        Task UpdateAsync(AttendanceRequest attendanceRequest);
        Task DeleteAsync(long id);

    }
}
