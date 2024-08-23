using KHRMS.Core;

namespace KHRMS.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KHRMSContextClass _dbContext;
        public ICandidateRepository Candidates { get; }

        public UnitOfWork(KHRMSContextClass dbContext,
                            ICandidateRepository candidateRepository)
        {
            _dbContext = dbContext;
            Candidates = candidateRepository;
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
