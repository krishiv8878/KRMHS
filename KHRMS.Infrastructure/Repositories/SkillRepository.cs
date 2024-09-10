using KHRMS.Core.Interfaces;
using KHRMS.Core;

namespace KHRMS.Infrastructure.Repositories
{
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(KHRMSContextClass dbcontext) : base(dbcontext)
        {
        }
    }
}
