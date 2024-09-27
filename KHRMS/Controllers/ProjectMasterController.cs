using KHRMS.Core;
using KHRMS.Infrastructure;
using KHRMS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KHRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectMasterController(IProjectMasterService projectMasterService) : ControllerBase
    {
        public readonly IProjectMasterService _projectMasterService = projectMasterService;

        /// <summary>
        /// Get the list of projectMaster
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProjectMaster")]
        public async Task<IActionResult> GetProjectMaster()
        {
            var projectMaster = await _projectMasterService.GetAllProjectMaster();
            if (projectMaster == null)
            {
                return NotFound();
            }
            // Use the wrapper class to create a consistent response
            var response = new ApiResponse<List<ProjectMaster>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = projectMaster.Any() ? ApiMessageConstant.ProjectMasterFound : ApiMessageConstant.ProjectMasterNotFound,
                Data = projectMaster.ToList()
            };
            return Ok(response);
        }


        /// <summary>
        /// Add a new ProjectMaster
        /// </summary>
    
        [HttpPost]
        [Route("AddProjectMaster")]
        public async Task<IActionResult> AddProjectMaster(ProjectMaster projectMaster)
        {
            var isProjectMasterAdded = await _projectMasterService.AddProjectMaster(projectMaster);
            if (isProjectMasterAdded)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.ProjectMasterAdded,
                    Data = isProjectMasterAdded
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.ProjectMasterNotAdded,
                    Data = isProjectMasterAdded
                };
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Update a existing candidate
        /// </summary>

        [HttpPut]
        [Route("UpdateProjectMaster")]
        public async Task<IActionResult> UpdateProjectMaster(ProjectMaster projectMaster)
        {
            var isProjectMasterEdited = await _projectMasterService.UpdateProjectMaster(projectMaster);
            if (isProjectMasterEdited)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.ProjectMasterUpdated,
                    Data = isProjectMasterEdited
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.ProjectMasterNotUpdated,
                    Data = isProjectMasterEdited
                };
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Delete existing candidate
        /// </summary>

        [HttpDelete]
        [Route("DeleteProjectMaster")]
        public async Task<IActionResult> DeleteCandidate(long projectMasterId)
        {
            var isProjectMasterDeleted = await _projectMasterService.DeleteProjectMaster(projectMasterId);
            if (isProjectMasterDeleted)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.ProjectMasterDeleted,
                    Data = isProjectMasterDeleted
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.ProjectMasterNotDeleted,
                    Data = isProjectMasterDeleted
                };
                return BadRequest(response);
            }
        }
    }
}