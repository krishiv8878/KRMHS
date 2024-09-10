using KHRMS.Constants;
using KHRMS.Core.Models;
using KHRMS.Infrastructure;
using KHRMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KHRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsMasterController(IAssetsMasterService AssetsMasterService) : ControllerBase
    {
        public readonly IAssetsMasterService _assetsMasterService = AssetsMasterService;


        [HttpGet]
        [Route("GetAssetsMaster")]
        public async Task<IActionResult> GetDesignations()
        {
            var assetsMaster = await _assetsMasterService.GetAllAssetsMaster();
            if (assetsMaster == null)
            {
                return NotFound();
            }
            // Use the wrapper class to create a consistent response
            var response = new ApiResponse<List<AssetsMaster>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = assetsMaster.Any() ? ApiMessageConstant.AssetsMasterFound : ApiMessageConstant.AssetsMasterNotFound,
                Data = assetsMaster.ToList()
            };
            return Ok(response);
        }

        [HttpPost]
        [Route("AddAssetsMaster")]
        public async Task<IActionResult> AddAssetsMaster(AssetsMaster assetsMaster)
        {
            var isAssetsMasterAdded = await _assetsMasterService.AddAssetsMaster(assetsMaster);
            if (isAssetsMasterAdded)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.AssetsMasterAdded,
                    Data = isAssetsMasterAdded
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.AssetsMasterNotAdded,
                    Data = isAssetsMasterAdded
                };
                return BadRequest(response);
            }
        }

        [HttpPut]
        [Route("UpdateAssetsMaster")]
        public async Task<IActionResult> UpdateAssetsMaster(AssetsMaster assetsMaster)
        {
            var isAssetsMasterEdited = await _assetsMasterService.UpdateAssetsMaster(assetsMaster);
            if (isAssetsMasterEdited)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.AssetsMasterUpdated,
                    Data = isAssetsMasterEdited
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.AssetsMasterNotUpdated,
                    Data = isAssetsMasterEdited
                };
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("DeleteAssetsMaster")]
        public async Task<IActionResult> DeleteAssetsMaster(long AssetsMasterId)
        {
            var isAssetsMasterDeleted = await _assetsMasterService.DeleteAssetsMaster(AssetsMasterId);
            if (isAssetsMasterDeleted)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.AssetsMasterDeleted,
                    Data = isAssetsMasterDeleted
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.AssetsMasterNotDeleted,
                    Data = isAssetsMasterDeleted
                };
                return BadRequest(response);
            }
        }
    }
}
