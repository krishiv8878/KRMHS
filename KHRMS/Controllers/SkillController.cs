using KHRMS.Core;
using KHRMS.Infrastructure;
using KHRMS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KHRMS
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController(ISkillService skillService) : ControllerBase
    {
        public readonly ISkillService _skillService = skillService;


        /// <summary>
        /// Get the List of Skills 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSkills")]

        public async Task<IActionResult> GetSkill()
        {
            var skills = await _skillService.GetAllSkills();
            if (skills == null)
            {
                return NotFound();
            }
            // Use the wrapper class to create a consistent response
            var response = new ApiResponse<List<Skill>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = skills.Any() ? ApiMessageConstant.SkillFound : ApiMessageConstant.NoSkillFound,
                Data = skills.ToList()
            };
            return Ok(response);
        }

        [HttpPost]
        [Route("AddSkills")]
        public async Task<IActionResult> AddSkill(Skill skill)
        {
            var isSkillAdded = await _skillService.AddSkill(skill);
            if (isSkillAdded)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.SkillAdded,
                    Data = isSkillAdded
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.SkillNotAdded,
                    Data = isSkillAdded
                };
                return BadRequest(response);
            }
        }

        [HttpPut]
        [Route("UpdateSkill")]
        public async Task<IActionResult> UpdateSkill(Skill skill)
        {
            var isSkillEdited = await _skillService.UpdateSkill(skill);
            if (isSkillEdited)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.SkillUpdated,
                    Data = isSkillEdited
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.SkillNotUpdated,
                    Data = isSkillEdited
                };
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("DeleteSkill")]
        public async Task<IActionResult> DeleteSkill(long skillId)
        {
            var isSkillDeleted = await _skillService.DeleteSkill(skillId);
            if (isSkillDeleted)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.SkillDeleted,
                    Data = isSkillDeleted
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.SkillNotDeleted,
                    Data = isSkillDeleted
                };
                return BadRequest(response);
            }
        }
    }
}
