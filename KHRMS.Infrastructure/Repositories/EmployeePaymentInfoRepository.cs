using KHRMS.Core;
using KHRMS.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace KHRMS.Infrastructure
{
    public class EmployeePaymentInfoRepository : GenericRepository<EmployeePaymentInfo>, IEmployeePaymentInfoRepository
    {
        public EmployeePaymentInfoRepository(KHRMSContextClass dbContext) : base(dbContext)
        {
        }
    }
}




