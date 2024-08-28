using KHRMS.Core;
using KHRMS.Infrastructure;
using KHRMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KHRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController(ICandidateService candidateService) : ControllerBase
    {
        public readonly ICandidateService _candidateService = candidateService;

        /// <summary>
        /// Get the list of candidates
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCandidates")]
        public async Task<IActionResult> GetCandidates()
        {
            var candidates = await _candidateService.GetAllCandidates();
            if (candidates == null)
            {
                return NotFound();
            }
            // Use the wrapper class to create a consistent response
            var response = new ApiResponse<List<Candidate>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = candidates.Any() ? "Candidates retrieved successfully" : "No Candidates found!",
                Data = candidates.ToList()
            };
            return Ok(response);
        }
        

        /// <summary>
        /// Add a new candidate
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCandidate")]
        public async Task<IActionResult> AddCandidate([FromBody] Candidate candidate)
        {
            var isCandidatedAdded = await _candidateService.CreateCandidate(candidate);
            if (isCandidatedAdded)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Candidate saved successfully",
                    Data = isCandidatedAdded
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Candidate were not saved successfully",
                    Data = isCandidatedAdded
                };
                return BadRequest();
            }
        }

        ///// <summary>
        ///// Update a existing candidate
        ///// </summary>
        ///// <param name="candidate"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("UpdateCandidate")]
        //public async Task<IActionResult> UpdateCandidate([FromBody] Candidate candidate)
        //{
        //    var isCandidatedEdited = await _candidateService.UpdateCandidate(candidate);
        //    if (isCandidatedEdited)
        //    {
        //        // Use the wrapper class to create a consistent response
        //        var response = new ApiResponse<bool>
        //        {
        //            StatusCode = (int)HttpStatusCode.OK,
        //            Message = "Candidate updated successfully",
        //            Data = isCandidatedEdited
        //        };
        //        return Ok(response);
        //    }
        //    else
        //    {
        //        var response = new ApiResponse<bool>
        //        {
        //            StatusCode = (int)HttpStatusCode.BadRequest,
        //            Message = "Candidate were not updated successfully",
        //            Data = isCandidatedEdited
        //        };
        //        return BadRequest();
        //    }
        //}
    }
}
