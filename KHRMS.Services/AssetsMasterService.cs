using KHRMS.Core;
using KHRMS.Core.Models;
using KHRMS.Services.Interfaces;

namespace KHRMS.Services
{
    public class AssetsMasterService(IUnitOfWork unitOfWork) : IAssetsMasterService
    {
        public IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<bool> AddAssetsMaster(AssetsMaster assetsMaster)
        {
            if (assetsMaster != null)
            {
                assetsMaster.CreatedDate = DateTime.Now;
                await _unitOfWork.AssetsMaster.Add(assetsMaster);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

      

        public async Task<bool> DeleteAssetsMaster(long assetsMasterId)
        {
            if (assetsMasterId > 0)
            {
                var assetsMasterDetail = await _unitOfWork.AssetsMaster.GetById(assetsMasterId);
                if (assetsMasterDetail != null)
                {
                    assetsMasterDetail.IsDeleted = true;
                    assetsMasterDetail.IsActive = false;

                    _unitOfWork.AssetsMaster.Update(assetsMasterDetail);
                    var result = _unitOfWork.Save();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<AssetsMaster>> GetAllAssetsMaster()
        {
            var assetsMasterDetail = await _unitOfWork.AssetsMaster.GetAll();
            return assetsMasterDetail;
        }

        public async Task<AssetsMaster> GetAssetsMasterById(int assetsMasterId)
        {
            if (assetsMasterId > 0)
            {
                var assetsMasterDetail = await _unitOfWork.AssetsMaster.GetAssetsMasterById(assetsMasterId);
                if (assetsMasterDetail != null)
                {
                    return assetsMasterDetail;
                }
            }
            return null;
        }

        

        public async Task<bool> UpdateAssetsMaster(AssetsMaster assetsMaster)
        {
            if (assetsMaster != null)
            {
                var assetsMasterDetail = await _unitOfWork.AssetsMaster.GetById(assetsMaster.Id);
                if (assetsMasterDetail != null)
                {
                    assetsMasterDetail.AssetsMasterName = assetsMaster.AssetsMasterName;

                    _unitOfWork.AssetsMaster.Update(assetsMasterDetail);
                    var result = _unitOfWork.Save();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        }
    }

