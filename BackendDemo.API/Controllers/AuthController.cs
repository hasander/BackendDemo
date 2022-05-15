using BackendDemo.Business.IServices;
using BackendDemo.Core.DTOs.Auth;
using BackendDemo.SharedLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BackendDemo.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly IAuthenticationService _authenticationService;
    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Login")]
    public async Task<AppResponse<TokenDTO>> Login(LoginDTO loginDto)
    {
        return await _authenticationService.CreateTokenAsync(loginDto);
    }
}
