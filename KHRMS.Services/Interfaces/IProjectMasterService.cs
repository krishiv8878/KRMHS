using KHRMS.Core;

namespace KHRMS.Services
{
    public interface IProjectMasterService
    {
        Task<bool> AddProjectMaster(ProjectMaster projectMaster);
        Task<IEnumerable<ProjectMaster>> GetAllProjectMaster();
        Task<ProjectMaster> GetProjectMasterById(int ProjectMasterId);
        Task<bool> UpdateProjectMaster(ProjectMaster projectMaster);
        Task<bool> DeleteProjectMaster(long ProjectMasterId);
    }
}
