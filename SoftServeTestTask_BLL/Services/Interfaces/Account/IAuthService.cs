using SoftServeTestTask_BLL.DTO.Account;
using SoftServeTestTask_BLL.DTO.Account.Login;
using SoftServeTestTask_BLL.DTO.Account.Register;

namespace SoftServeTestTask_BLL.Services.Interfaces.Account
{
    public interface IAuthService
    {
        Task<UserDTO> Register(RegisterRequestDTO registerRequest);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest);
        Task<bool> AssignRole(string email, string roleName);
    }
}
