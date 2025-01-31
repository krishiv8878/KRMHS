using KHRMS.Core;


namespace KHRMS.Infrastructure
{
    public class EmployeeRoleMappingRepository : GenericRepository<EmployeeRoleMapping>, IEmployeeRoleMappingRepository
    {
        public EmployeeRoleMappingRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}