using KHRMS.Core;
using KHRMS.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace KHRMS.Infrastructure
{
    public class EmployeeAttendanceRepository : GenericRepository<EmployeeAttendance>, IEmployeeAttendanceRepository
    {

        public EmployeeAttendanceRepository(KHRMSContextClass dbContext) : base(dbContext)
        {
        }
     
    }
}




