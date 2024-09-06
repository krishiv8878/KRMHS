using KHRMS.Core.Interfaces;
using KHRMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRMS.Infrastructure.Repositories
{
    public class AssetsMasterRepository : GenericRepository<AssetsMaster>, IAssetsMasterRepository
    {
        public AssetsMasterRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}
