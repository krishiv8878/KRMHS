using Azure;
using KHRMS.Core;
using KHRMS.Infrastructure;
using KHRMS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KHRMS
{
    /// <summary>
    /// API Controller for managing Employee Payment Information.
    /// Provides endpoints to Create, Read, Update, and Delete employee payment records.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]

    public class EmployeePaymentInfoController(IEmployeePaymentInfoService employeePaymentInfoService) : ControllerBase

    {
        private readonly IEmployeePaymentInfoService _employeePaymentInfoService = employeePaymentInfoService;

        [HttpGet("GetAllPaymentInfo")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _employeePaymentInfoService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<EmployeePaymentInfo>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Employee payment information retrieved successfully.",
                Data = entities
            });
        }


        /// <summary>
        /// Retrieves employee payment information by ID.
        /// </summary>
        /// <param name="id">Employee Payment Info ID</param>

        [HttpGet("GetPaymentInfoProfileById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var entity = await _employeePaymentInfoService.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound(new ApiResponse<EmployeePaymentInfo>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Employee payment information not found.",
                    Data = null
                });
            }
            return Ok(new ApiResponse<EmployeePaymentInfo>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Employee payment information retrieved successfully.",
                Data = entity
            });
        }

        /// <summary>
        /// Creates a new employee payment information record.
        /// </summary>
        /// <param name="entity">Employee Payment Info object</param>

        [HttpPost("CreatePaymentInfo")]
        public async Task<IActionResult> Create([FromBody] EmployeePaymentInfo entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Invalid data.",
                    Data = false
                });
            }
            await _employeePaymentInfoService.AddAsync(entity);
            return Ok(new ApiResponse<bool>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Employee payment information added successfully.",
                Data = true
            });
        }

        /// <summary>
        /// Updates an existing employee payment information record.
        /// </summary>
        /// <param name="id">Employee Payment Info ID</param>
        /// <param name="entity">Updated Employee Payment Info object</param>

        [HttpPut("UpdatePaymentInfo/{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] EmployeePaymentInfo entity)
        {
            if (!ModelState.IsValid || id != entity.Id)
            {
                return BadRequest(new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Invalid data.",
                    Data = false
                });
            }
            await _employeePaymentInfoService.UpdateAsync(entity);
            return Ok(new ApiResponse<bool>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Employee payment information updated successfully.",
                Data = true
            });
        }

        /// <summary>
        /// Deletes an employee payment information record by ID.
        /// </summary>
        /// <param name="id">Employee Payment Info ID</param>
        [HttpDelete("DeletePaymentInfo/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _employeePaymentInfoService.DeleteAsync(id);
            return Ok(new ApiResponse<bool>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Employee payment information deleted successfully.",
                Data = true
            });
        }
    }


}
