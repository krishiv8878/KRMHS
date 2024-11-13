using KHRMS.Core;
using KHRMS.Infrastructure;
using KHRMS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KHRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController(IUserRegistrationService userRegistrationService) : ControllerBase
    {
        public readonly IUserRegistrationService _userRegistrationService = userRegistrationService;

        [HttpPost]
        [Route("Registration")]

        public async Task<IActionResult> Registration(UserRegistration userRegistration)
        {

            var isRegistrationUserAdded = await _userRegistrationService.GetRegistrationByUser(userRegistration);
            if (isRegistrationUserAdded)
            {
                // Use the wrapper class to create a consistent response
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.RegistrationUserAdded,
                    Data = isRegistrationUserAdded
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.RegistrationUserNotAdded,
                    Data = isRegistrationUserAdded
                };
                return BadRequest(response);
            }
        }

    }
}
