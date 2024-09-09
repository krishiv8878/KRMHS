using KHRMS.Core;
using KHRMS.Core.Interfaces;
using KHRMS.Core.Models;

namespace KHRMS.Infrastructure.Repositories;

    public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
{
        public CandidateRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
