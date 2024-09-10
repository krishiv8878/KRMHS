using KHRMS.Core;


namespace KHRMS.Infrastructure
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}
