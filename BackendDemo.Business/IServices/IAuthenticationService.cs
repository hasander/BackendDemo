using BackendDemo.Core.DTOs.Auth;
using BackendDemo.SharedLibrary.DTOs;

namespace BackendDemo.Business.IServices;

public interface IAuthenticationService
{
    Task<AppResponse<TokenDTO>> CreateTokenAsync(LoginDTO loginDto);
}
