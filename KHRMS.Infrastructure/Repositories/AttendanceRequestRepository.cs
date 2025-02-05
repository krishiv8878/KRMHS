using System.Collections.Generic;
using System.Threading.Tasks;
using KHRMS.Core;
using Microsoft.EntityFrameworkCore;

namespace KHRMS.Infrastructure
{
    public class AttendanceRequestRepository : GenericRepository<AttendanceRequest>, IAttendanceRequestRepository

    {
        public AttendanceRequestRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }

    }

    
}
