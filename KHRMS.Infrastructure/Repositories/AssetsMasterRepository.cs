using KHRMS.Core.Interfaces;
using KHRMS.Core;

namespace KHRMS.Infrastructure.Repositories
{
    public class AssetsMasterRepository : GenericRepository<AssetsMaster>, IAssetsMasterRepository
    {
        public AssetsMasterRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}
