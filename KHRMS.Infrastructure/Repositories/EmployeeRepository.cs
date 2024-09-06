using KHRMS.Core;
using KHRMS.Core.Models;

namespace KHRMS.Infrastructure
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}
