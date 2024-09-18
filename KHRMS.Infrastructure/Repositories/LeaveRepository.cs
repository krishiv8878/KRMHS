using KHRMS.Core;

namespace KHRMS.Infrastructure
{
    public class LeaveRepository : GenericRepository<LeaveType>, ILeaveRepository
    {
        public LeaveRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}
