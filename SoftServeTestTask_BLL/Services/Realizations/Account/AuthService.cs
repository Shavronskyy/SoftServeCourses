using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SoftServeTestTask_BLL.DTO.Account;
using SoftServeTestTask_BLL.DTO.Account.Login;
using SoftServeTestTask_BLL.DTO.Account.Register;
using SoftServeTestTask_BLL.Services.Interfaces.Account;
using SoftServeTestTask_DAL.Entities.Account;
using SoftServeTestTask_DAL.Repositories.Interfaces.AccountRep;

namespace SoftServeTestTask_BLL.Services.Realizations.Account
{
    public class AuthService : IAuthService
    {
        private readonly IAccountRepository _repo;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ILogger<AuthService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(IAccountRepository repo, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager
                          ,ILogger<AuthService> logger, IJwtTokenGenerator jwtTokenGenerator)
        {
            _repo = repo;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = await _repo.GetUserByEmail(email);
            if(user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest)
        {
            var user = await _repo.GetUserByUserName(loginRequest.UserName);

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

            if(user == null || isValid == false)
            {
                return new LoginResponseDTO()
                {
                    User = null,
                    Token = ""
                };
            }
            var token = _jwtTokenGenerator.GenerateToken(user);
            UserDTO userDTO = new()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name
            };

            LoginResponseDTO response = new()
            {
                User = userDTO,
                Token = token
            };

            return response;
        }

        public async Task<UserDTO> Register(RegisterRequestDTO registerRequest)
        {
            ApplicationUser user = new()
            {
                UserName = registerRequest.Email,
                Email = registerRequest.Email,
                NormalizedEmail = registerRequest.Email.ToUpper(),
                Name = registerRequest.Name
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registerRequest.Password);
                if (result.Succeeded)
                {
                    var userToReturn = await _repo.GetUserByUserName(registerRequest.Email);

                    UserDTO userDto = new()
                    {
                        Email = userToReturn.Email,
                        Id = userToReturn.Id,
                        Name = userToReturn.Name,
                    };

                    return userDto;
                }
            }
            catch (Exception ex)
            {
                var message = "Something is went wrong with registration";
                _logger.LogError(message);
                throw new BadHttpRequestException(message);
            }
            return new UserDTO();
        }
    }
}
