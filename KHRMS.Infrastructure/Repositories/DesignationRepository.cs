using KHRMS.Core;

namespace KHRMS.Infrastructure
{
    public class DesignationRepository : GenericRepository<Designation>, IDesignationRepository
    {
        public DesignationRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}
