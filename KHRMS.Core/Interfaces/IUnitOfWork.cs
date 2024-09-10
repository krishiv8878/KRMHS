namespace KHRMS.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICandidateRepository Candidates { get; }
        int Save();
    }
}
