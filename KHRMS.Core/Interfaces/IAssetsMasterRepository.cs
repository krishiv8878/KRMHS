using KHRMS.Core.Models;

namespace KHRMS.Core.Interfaces
{
    public interface IAssetsMasterRepository : IGenericRepository<AssetsMaster>
    {
        Task<AssetsMaster> GetAssetsMasterById(int assetsMasterId);
    }
}
