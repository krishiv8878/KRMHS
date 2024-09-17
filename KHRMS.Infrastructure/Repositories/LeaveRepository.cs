using KHRMS.Core.Interfaces;
using KHRMS.Core.Models;
using KHRMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRMS.Infrastructure.Repositories
{
     public class LeaveRepository : GenericRepository<LeaveType>, ILeaveRepository
    {
        public LeaveRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}
