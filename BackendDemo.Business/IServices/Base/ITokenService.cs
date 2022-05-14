using BackendDemo.Core.DTOs;
using BackendDemo.Core.DTOs.Auth;
using BackendDemo.SharedLibrary.DTOs;

namespace BackendDemo.Business.IServices;

public interface ITokenService
{
    Task<AppResponse<TokenDTO>> CreateToken(UserDTO user); 

}
