using KHRMS.Core.Models;

namespace KHRMS.Core.Interfaces
{
    public interface IAssetsMasterRepository : IGenericRepository<AssetsMaster>
    {
        Task<AssetsMaster> Delete(long assetsMasterId);
    }
}
