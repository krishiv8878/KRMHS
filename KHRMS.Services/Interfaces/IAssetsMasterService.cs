using KHRMS.Core;

namespace KHRMS.Services
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
