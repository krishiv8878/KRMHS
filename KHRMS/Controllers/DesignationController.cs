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
    public class DesignationController(IDesignationService designationService) : ControllerBase
    {
        public readonly IDesignationService _designationService = designationService;


        [HttpGet]
        [Route("GetDesignations")]
        public async Task<IActionResult> GetDesignations()
        {
            var designations = await _designationService.GetAllDesignations();
            if (designations == null)
            {
                return NotFound();
            }
            // Use the wrapper class to create a consistent response
            var response = new ApiResponse<List<Designation>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = designations.Any() ? ApiMessageConstant.DesgnationFound : ApiMessageConstant.NoDesgnationFound,
                Data = designations.ToList()
            };
            return Ok(response);
        }

        [HttpPost]
        [Route("AddDesignation")]
        public async Task<IActionResult> AddDesignation(Designation designation)
        {
            var isDesignationAdded = await _designationService.CreateDesignation(designation);
            if (isDesignationAdded)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.DesignationAdded,
                    Data = isDesignationAdded
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.DesignationNotAdded,
                    Data = isDesignationAdded
                };
                return BadRequest(response);
            }
        }

        [HttpPut]
        [Route("UpdateDesignation")]
        public async Task<IActionResult> UpdateDesignation(Designation designation)
        {
            var isDesignationEdited = await _designationService.UpdateDesignation(designation);
            if (isDesignationEdited)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.DesignationUpdated,
                    Data = isDesignationEdited
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.DesignationNotUpdated,
                    Data = isDesignationEdited
                };
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("DeleteDesignation")]
        public async Task<IActionResult> DeleteDesignation(long designationId)
        {
            var isDesignationDeleted = await _designationService.DeleteDesignation(designationId);
            if (isDesignationDeleted)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.DesignationDeleted,
                    Data = isDesignationDeleted
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.DesignationNotDeleted,
                    Data = isDesignationDeleted
                };
                return BadRequest(response);
            }
        }
    }
}
