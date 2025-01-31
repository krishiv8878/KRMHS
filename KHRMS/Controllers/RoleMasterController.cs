using KHRMS.Core;
using KHRMS.Infrastructure;
using KHRMS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KHRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleMasterController(IRoleMasterService roleMasterService) : ControllerBase
    {
        public readonly IRoleMasterService _roleMasterService = roleMasterService;
        /// <summary>
        /// Get List Of RoleMaster
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var rolemaster = await _roleMasterService.GetAllRoleMaster();
            if (rolemaster == null)
            {
                return NotFound();
            }
            var response = new ApiResponse<List<RoleMaster>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = rolemaster.Any() ? ApiMessageConstant.RoleMasterFound : ApiMessageConstant.NoRoleMasterFound,
                Data = rolemaster.ToList()
            };

            return Ok(response);
        }
        /// <summary>
        /// Add New RoleMaster
        /// </summary>
        /// <param name="roleMaster"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole(RoleMaster roleMaster)
        {
            var isRoleMasterAdded = await _roleMasterService.AddRoleMaster(roleMaster);
            if (isRoleMasterAdded)
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.RoleMasterAdded,
                    Data = isRoleMasterAdded
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.RoleMasterNotAdded,
                    Data = isRoleMasterAdded
                };
                return BadRequest(response);
            }
        }
        /// <summary>
        /// Update RoleMaster
        /// </summary>
        /// <param name="roleMaster"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateRole")]
        public async Task<IActionResult> UpdateRole(RoleMaster roleMaster)
        {
            var isRoleMasterUpdated = await _roleMasterService.UpdateRoleMaster(roleMaster);
            if (isRoleMasterUpdated)
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.RoleMasterUpdated,
                    Data = isRoleMasterUpdated
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.RoleMasterNotUpdated,
                    Data = isRoleMasterUpdated
                };
                return BadRequest(response);
            }
        }
        /// <summary>
        /// Delete RoleMaster
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<IActionResult> DeleteRole(long RoleId)
        {
            var isRoleMasterDeleted = await _roleMasterService.DeleteRoleMaster(RoleId);
            if (isRoleMasterDeleted)
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.RoleMasterDeleted,
                    Data = isRoleMasterDeleted
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.RoleMasterNotDeleted,
                    Data = isRoleMasterDeleted
                };
                return BadRequest(response);
            }
        }
    }
}
