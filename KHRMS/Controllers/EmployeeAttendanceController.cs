using KHRMS.Core;
using KHRMS.Infrastructure;
using KHRMS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KHRMS
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAttendanceController(IEmployeeAttendanceService employeeAttendanceService) : ControllerBase

    {
        private readonly IEmployeeAttendanceService _attendanceService = employeeAttendanceService;

    

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var attendances = await _attendanceService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<EmployeeAttendance>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Employee attendance records retrieved successfully.",
                Data = attendances
            });
        }
       

        //[HttpGet("GetById/{id}")]
        //public async Task<IActionResult> GetById(long id)
        //{
        //    var attendance = await _attendanceService.GetByIdAsync(id);
        //    if (attendance == null)
        //        return NotFound(new ApiResponse<string> { StatusCode = (int)HttpStatusCode.NotFound, Message = "Record not found" });

        //    return Ok(new ApiResponse<EmployeeAttendance>
        //    {
        //        StatusCode = (int)HttpStatusCode.OK,
        //        Message = "Record found.",
        //        Data = attendance
        //    });
        //}

        [HttpGet]
        [Route("GetByEmployeeId/{employeeId}")]
        public async Task<IActionResult> GetByEmployeeId(long employeeId)
        {
            var attendances = await _attendanceService.GetByEmployeeIdAsync(employeeId);
            if (attendances == null)
            {
                return NotFound(new ApiResponse<EmployeeAttendance>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = ApiMessageConstant.AttendanceRequestNotFound,
                    Data = null
                });
            }
            var response = new ApiResponse<EmployeeAttendance>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = ApiMessageConstant.AttendanceRequestFound,
                Data = attendances
            };
            return Ok(response);
        }
      

        [HttpPost]
        [Route("AddEmployeeAttendanceRequest")]
        public async Task<IActionResult> AddEmployeeAttendanceRequest([FromBody] EmployeeAttendance attendance)
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
            await _attendanceService.AddAsync(attendance);
            var response = new ApiResponse<bool>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = ApiMessageConstant.AttendanceRequestAdded,
                Data = true
            };
            return Ok(response);
        }
 
        [HttpPut]
        [Route("UpdateEmployeeAttendanceRequest")]
        public async Task<IActionResult> UpdateEmployeeAttendanceRequest(EmployeeAttendance attendance)
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
            await _attendanceService.UpdateAsync(attendance);
            var response = new ApiResponse<bool>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = ApiMessageConstant.AttendanceRequestUpdated,
                Data = true
            };
            return Ok(response);

        }
       
        //extra
        [HttpDelete]
        [Route("DeleteEmployeeAttendanceRequest/{id}")]
        public async Task<IActionResult> DeleteEmployeeAttendanceRequest(long id)
        {
            await _attendanceService.DeleteAsync(id);
            var response = new ApiResponse<bool>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = ApiMessageConstant.AttendanceRequestDeleted,
                Data = true
            };
            return Ok(response);
        }
    }



}



