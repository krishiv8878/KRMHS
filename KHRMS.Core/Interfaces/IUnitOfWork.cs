using KHRMS.Core.Interfaces;

namespace KHRMS.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICandidateRepository Candidates { get; }
        ISkillRepository Skills { get; }
        IDesignationRepository Designations { get; }
        IAssetsMasterRepository AssetsMaster { get; }
        int Save();
    }
}
