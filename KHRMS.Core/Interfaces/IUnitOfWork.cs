using KHRMS.Core.Interfaces;

namespace KHRMS.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICandidateRepository Candidates { get; }
        ISkillRepository Skills { get; }
        int Save();
    }
}
