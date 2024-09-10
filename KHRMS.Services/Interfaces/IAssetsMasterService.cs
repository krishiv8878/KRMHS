using KHRMS.Core.Models;

namespace KHRMS.Services.Interfaces
{
    public interface IAssetsMasterService
    {
        Task<bool> AddAssetsMaster(AssetsMaster assetsMaster);
        Task<IEnumerable<AssetsMaster>> GetAllAssetsMaster();
        Task<AssetsMaster> GetAssetsMasterById(int assetsMasterId);
        Task<bool> UpdateAssetsMaster(AssetsMaster assetsMaster);
        Task<bool> DeleteAssetsMaster(long assetsMasterId);

    }
}
