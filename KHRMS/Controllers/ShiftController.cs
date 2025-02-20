using KHRMS.Core;
using KHRMS.Infrastructure;
using KHRMS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KHRMS
{
    /// <summary>
    /// API Controller for managing Employee Shift Information.
    /// Provides endpoints to Create, Read, Update, and Delete employee payment records.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController(IShiftService shiftService ) : ControllerBase

    {
        public readonly IShiftService _shiftService = shiftService;
      

        [HttpGet("GetAllShifts")]
        public async Task<IActionResult> GetAllShifts()
        {
            var entities = await _shiftService.GetAllShiftsAsync();
            return Ok(new ApiResponse<IEnumerable<ShiftMaster>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = ApiMessageConstant.AllEmployeeShiftRecordRequestsFound,
                Data = entities
            });
        }

        /// <summary>
        /// Retrieves employee shift information by ID.
        /// </summary>
        /// <param name="id">Employee Shift Info ID</param>

        [HttpGet("GetShiftById/{id}")]
        public async Task<IActionResult> GetShiftById(long id)
        {
            var shift = await _shiftService.GetShiftByIdAsync(id);
            if (shift == null)
            {
                return NotFound(new ApiResponse<ShiftMaster>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = ApiMessageConstant.EmployeeShiftRequestsNotFound,
                    Data = null
                });
            }
            return Ok(new ApiResponse<ShiftMaster>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = ApiMessageConstant.EmployeeShiftRequestsFound,
                Data = shift
            });
        }

        /// <summary>
        /// Creates a new employee Shift information record.
        /// </summary>
        /// <param name="shift">Employee Shift Info object</param>

        [HttpPost("CreateShiftType")]
        public async Task<IActionResult> AddShift(ShiftMaster shift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.InvalidDataofShiftInfo,
                    Data = false
                });
            }
            await _shiftService.AddShiftAsync(shift);
            CreatedAtAction(nameof(GetShiftById), new { id = shift.Id }, shift);
            return Ok(new ApiResponse<bool>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = ApiMessageConstant.EmployeeShifttInfoAdd,
                Data = true
            });
        }

        /// <summary>
        /// Updates an existing employee Shift information record.
        /// </summary>
        /// <param name="shiftMaster">Updated Employee Shift Info object</param>

        [HttpPut("UpdateShift")]
        public async Task<IActionResult> Update(ShiftMaster shiftMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.InvalidData,
                    Data = false
                });
            }
            await _shiftService.UpdateShiftAsync(shiftMaster);
            return Ok(new ApiResponse<bool>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = ApiMessageConstant.ShiftInfoeRequestUpdated,
                Data = true
            });
        }

        /// <summary>
        /// Deletes an employee shift information record by ID.
        /// </summary>
        /// <param name="id">Employee shift Info ID</param>

        [HttpDelete("DeleteShift/{id}")]
        public async Task<IActionResult> DeleteShift(long id)
        {
            var shift = await _shiftService.GetShiftByIdAsync(id);
            if (shift == null)
            {
                return NotFound(new ApiResponse<ShiftMaster>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = ApiMessageConstant.EmployeeShiftRequestsNotFound,
                    Data = null
                });
            }

            await _shiftService.DeleteShiftAsync(id);
            return Ok(new ApiResponse<bool>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = ApiMessageConstant.ShiftInfoRequestDeleted,
                Data = true
            });
        }

       
    }
}


