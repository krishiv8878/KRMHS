using KHRMS.Core;


namespace KHRMS.Infrastructure
{
    public class RoleMasterRepository : GenericRepository<RoleMaster>, IRoleMasterRepository
    {
        public RoleMasterRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}