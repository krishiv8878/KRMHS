using KHRMS.Core;

namespace KHRMS.Services
{
    public interface ILeaveTypeService
    {
        Task<bool> AddLeaveType(LeaveType leaveType);
        Task<IEnumerable<LeaveType>> GetAllLeaveType();
        Task<LeaveType> GetLeaveTypeById(int LeaveTypeId);
        Task<bool> UpdateLeaveType(LeaveType leaveType);
        Task<bool> DeleteLeaveType(long LeaveTypeId);
    }
}
