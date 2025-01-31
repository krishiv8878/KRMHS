using KHRMS.Core;

namespace KHRMS.Services
{
    public interface IRoleMasterService
    {
        Task<bool> AddRoleMaster(RoleMaster roleMaster);
        Task<IEnumerable<RoleMaster>> GetAllRoleMaster();
        Task<RoleMaster> GetRoleMasterById(long roleMasterId);
        Task<bool> UpdateRoleMaster(RoleMaster roleMaster);
        Task<bool> DeleteRoleMaster(long roleMasterId);
    }
}
