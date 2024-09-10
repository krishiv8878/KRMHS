using KHRMS.Core;

namespace KHRMS.Infrastructure
{
    public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}
