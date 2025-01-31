using Azure;
using KHRMS.Core;
using KHRMS.Infrastructure;
using KHRMS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KHRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoleMappingController(IEmployeeRoleMappingService employeeRoleMappingService) : ControllerBase
    {
        public readonly IEmployeeRoleMappingService _employeeRoleMappingService = employeeRoleMappingService;
        /// <summary>
        /// Get List Of EmployeeRoleMapping
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmployeeRoles")]
        public async Task<IActionResult> GetEmployeeRoles()
        {
            var employeeroleMapping = await _employeeRoleMappingService.GetAllEmployeeRoleMapping();
            if (employeeroleMapping == null)
            {
                return NotFound();
            }
            var response = new ApiResponse<List<EmployeeRoleMapping>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = employeeroleMapping.Any() ? ApiMessageConstant.EmployeeRoleMapping: ApiMessageConstant.NoEmployeeRoleMappingFound,
                Data = employeeroleMapping.ToList()
            };
            return Ok(response);
        }
        /// <summary>
        /// Add New EmployeeRoleMapping
        /// </summary>
        /// <param name="employeeRoleMapping"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AssignEmployeeRole")]
        public async Task<IActionResult> AssignEmployeeRole(EmployeeRoleMapping employeeRoleMapping)
        {
            var isEmployeRoleMappingAdded = await _employeeRoleMappingService.CreateEmployeeRoleMapping(employeeRoleMapping);
            if (isEmployeRoleMappingAdded)
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.EmployeeRoleMappingAdded,
                    Data = isEmployeRoleMappingAdded
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.EmployeeRoleMappingNotAdded,
                    Data = isEmployeRoleMappingAdded
                };
                return BadRequest(response);
            }
        }
        /// <summary>
        /// Update EmployeeRoleMapping
        /// </summary>
        /// <param name="employeeRoleMapping"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateEmployeeRole")]
        public async Task<IActionResult> UpdateEmployeeRole(EmployeeRoleMapping employeeRoleMapping)
        {
            var isEmployeRoleMappingUpdated = await _employeeRoleMappingService.UpdateEmployeeRoleMapping(employeeRoleMapping);
            if (isEmployeRoleMappingUpdated)
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.EmployeeRoleMappingUpdated,
                    Data = isEmployeRoleMappingUpdated
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.EmployeeRoleMappingNotUpdated,
                    Data = isEmployeRoleMappingUpdated
                };
                return BadRequest(response);
            }

        }
        /// <summary>
        /// Delete EmployeeRoleMapping
        /// </summary>
        /// <param name="employeeRoleMappingId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteEmployeeRole")]
        public async Task<IActionResult> DeleteEmployeeRole(long employeeRoleMappingId)
        {
            var isEmployeRoleMappingDeleted = await _employeeRoleMappingService.DeleteEmployeeRoleMapping(employeeRoleMappingId);
            if (isEmployeRoleMappingDeleted)
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.EmployeeRoleMappingDeleted,
                    Data = isEmployeRoleMappingDeleted
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.EmployeeRoleMappingNotDeleted,
                    Data = isEmployeRoleMappingDeleted
                };
                return BadRequest(response);
            }
        }
    }
}
