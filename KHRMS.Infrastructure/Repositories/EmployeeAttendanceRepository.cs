using KHRMS.Core;

namespace KHRMS.Infrastructure
{
    public class EmployeeAttendanceRepository : GenericRepository<EmployeeAttendance>, IEmployeeAttendanceRepository
    {
        public EmployeeAttendanceRepository(KHRMSContextClass dbContext) : base(dbContext)
        {
        }
     
    }
}




