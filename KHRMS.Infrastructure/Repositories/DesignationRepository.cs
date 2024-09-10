using KHRMS.Core;
using KHRMS.Core.Interfaces;

namespace KHRMS.Infrastructure.Repositories
{
    public class DesignationRepository : GenericRepository<Designation>, IDesignationRepository
    {
        public DesignationRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}
