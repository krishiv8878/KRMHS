using KHRMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRMS.Services.Interfaces
{
    public  interface IAssetsMasterService
    {
        Task<bool> AddAssetsMaster(AssetsMaster assetsMaster);
        Task<IEnumerable<AssetsMaster>> GetAllAssetsMaster();
        Task<AssetsMaster> GetAssetsMasterById();
        Task<bool> UpdateAssetsMaster(AssetsMaster assetsMaster);
        Task<bool> DeleteAssetsMaster(long AssetsMasterId);

    }
}
