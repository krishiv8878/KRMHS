using KHRMS.Core.Interfaces;
using KHRMS.Core;

namespace KHRMS.Infrastructure.Repositories
{
    public class LeaveRepository : GenericRepository<LeaveType>, ILeaveRepository
    {
        public LeaveRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}
