using KHRMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetCandidates()
        {
            var candidates = await _candidateService.GetAllCandidates();
            if (candidates == null)
            {
                return NotFound();
            }
            return Ok(candidates);
        }
    }
}
