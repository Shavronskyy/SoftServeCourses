using Microsoft.AspNetCore.Mvc;
using SoftServeTestTask_BLL.DTO.Account.Login;
using SoftServeTestTask_BLL.DTO.Account.Register;
using SoftServeTestTask_BLL.Services.Interfaces.Account;

namespace SoftServeTestTask_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _service;

        public AccountController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequestDTO request)
        {
            var response = await _service.Register(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var response = await _service.Login(request);
            if(response == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegisterRequestDTO request)
        {
            var IsAssignRoleSuccess = await _service.AssignRole(request.Email, request.Role.ToUpper());
            if (!IsAssignRoleSuccess)
            {
                return BadRequest();
            }

            return Ok(IsAssignRoleSuccess);
        }
    }
}
