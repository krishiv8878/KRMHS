using KHRMS.Infrastructure;
using KHRMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KHRMS
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController(IUserLoginService userLoginService) : ControllerBase
    {
        public readonly IUserLoginService _userLoginService = userLoginService;

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login(string email , string password)
        {
            var isuserLoginAdded = await _userLoginService.GetUserLoginById(email , password);
            if (isuserLoginAdded)
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = ApiMessageConstant.UserLoginByIdAdded,
                    Data = isuserLoginAdded
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ApiMessageConstant.UserLoginByIdNotAdded,
                    Data = isuserLoginAdded
                };
                return BadRequest(response);
            }
        }

       
    }
}
