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
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAuthService service, ILogger<AccountController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequestDTO request)
        {
            var response = await _service.Register(request);

            if (string.IsNullOrEmpty(response.Email))
            {
                var message = "Wrong password or email";
                _logger.LogError(message);
                return NotFound(message);
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var response = await _service.Login(request);
            if (response.User is null)
            {
                var message = "Wrong password or email";
                _logger.LogError(message);
                return NotFound(message);
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
                var message = "Assign role failed";
                _logger.LogError(message);
                return BadRequest(message);
            }

            return Ok(IsAssignRoleSuccess);
        }
    }
}
