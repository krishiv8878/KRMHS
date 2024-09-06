using KHRMS.Core;
using KHRMS.Core.Interfaces;
using KHRMS.Core.Models;
using KHRMS.Infrastructure.Repositories;

namespace KHRMS.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KHRMSContextClass _dbContext;
        public ICandidateRepository Candidates { get; }

        public ISkillRepository Skills { get; }
        public IDesignationRepository Designations { get; }

        public IAssetsMasterRepository AssetsMaster { get; }

        public UnitOfWork(KHRMSContextClass dbContext,
                            ICandidateRepository candidateRepository,ISkillRepository skillRepository,IDesignationRepository designationRepository, IAssetsMasterRepository assetsMasterRepository)
        {
            _dbContext = dbContext;
            Candidates = candidateRepository;
            Skills = skillRepository;
            Designations = designationRepository;
            AssetsMaster = assetsMasterRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
