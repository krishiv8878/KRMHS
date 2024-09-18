using KHRMS.Core;
using KHRMS.Infrastructure;
using KHRMS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KHRMS
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController(ILeaveTypeService leaveTypeService) : ControllerBase
    {
        public readonly ILeaveTypeService _leaveTypeService = leaveTypeService;


        [HttpGet]
        [Route("GetLeaveType")]
        public async Task<IActionResult> GetLeaveType()
        {
            var leaveType = await _leaveTypeService.GetAllLeaveType();
            if (leaveType == null)
            {
                return NotFound();
            }
            // Use the wrapper class to create a consistent response
            var response = new ApiResponse<List<LeaveType>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = leaveType.Any() ? ApiMessageConstant.LeaveTypeFound : ApiMessageConstant.LeaveTypeNotFound,
                Data = leaveType.ToList()
            };
            return Ok(response);
        }

        [HttpPost]
        [Route("AddLeaveType")]
        public async Task<IActionResult> AddLeaveType(LeaveType leaveType)
        {
            var isLeaveTypeAdded = await _leaveTypeService.AddLeaveType(leaveType);
            if (isLeaveTypeAdded)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.LeaveTypeAdded,
                    Data = isLeaveTypeAdded
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.LeaveTypeNotAdded,
                    Data = isLeaveTypeAdded
                };
                return BadRequest(response);
            }
        }

        [HttpPut]
        [Route("UpdateLeaveType")]
        public async Task<IActionResult> UpdateLeaveType(LeaveType leaveType)
        {
            var isLeaveTypeEdited = await _leaveTypeService.UpdateLeaveType(leaveType);
            if (isLeaveTypeEdited)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.LeaveTypeUpdated,
                    Data = isLeaveTypeEdited
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.DesignationNotUpdated,
                    Data = isLeaveTypeEdited
                };
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("DeleteLeaveType")]
        public async Task<IActionResult> DeleteLeaveType(long LeaveTypeId)
        {
            var isLeaveTypeDeleted = await _leaveTypeService.DeleteLeaveType(LeaveTypeId);
            if (isLeaveTypeDeleted)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.LeaveTypeDeleted,
                    Data = isLeaveTypeDeleted
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.DesignationNotDeleted,
                    Data = isLeaveTypeDeleted
                };
                return BadRequest(response);
            }
        }
    }
}
