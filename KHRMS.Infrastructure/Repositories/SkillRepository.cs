using KHRMS.Core;

namespace KHRMS.Infrastructure
{
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(KHRMSContextClass dbcontext) : base(dbcontext)
        {
        }
    }
}
