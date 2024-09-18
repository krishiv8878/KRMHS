using KHRMS.Core;

namespace KHRMS.Infrastructure
{
    public class AssetsMasterRepository : GenericRepository<AssetsMaster>, IAssetsMasterRepository
    {
        public AssetsMasterRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}
