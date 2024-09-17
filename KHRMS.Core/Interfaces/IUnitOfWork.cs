using KHRMS.Core.Interfaces;

namespace KHRMS.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICandidateRepository Candidates { get; }
        ISkillRepository Skills { get; }
        IDesignationRepository Designations { get; }
        IEmployeeRepository Employees { get; }
        IHolidayRepository Holidays { get; }
        ILeaveRepository LeaveType { get; }
        IAssetsMasterRepository AssetsMasters { get; }

        int Save();
    }
}
