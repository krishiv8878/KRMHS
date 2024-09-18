using KHRMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRMS.Services.Interfaces
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
