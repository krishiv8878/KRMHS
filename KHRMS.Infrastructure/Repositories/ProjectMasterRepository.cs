using KHRMS.Core;

namespace KHRMS.Infrastructure
{
    public class ProjectMasterRepository : GenericRepository<ProjectMaster>, IProjectMasterRepository
    {
        public ProjectMasterRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}
