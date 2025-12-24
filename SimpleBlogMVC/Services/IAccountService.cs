using SimpleBlogMVC.DTOs;

namespace SimpleBlogMVC.Services;

public interface IAccountService
{
    Task<Response<LoginResponseDTO>> LoginAsync(LoginDTO loginDto);
    Task<Response<RegisterDTO>> RegisterAsync(RegisterDTO model);
}