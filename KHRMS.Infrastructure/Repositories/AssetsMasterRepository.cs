using KHRMS.Core.Interfaces;
using KHRMS.Core.Models;

namespace KHRMS.Infrastructure.Repositories
{
    public class AssetsMasterRepository : GenericRepository<AssetsMaster>, IAssetsMasterRepository
    {
        public AssetsMasterRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}
