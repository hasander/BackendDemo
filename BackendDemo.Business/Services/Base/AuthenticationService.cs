using BackendDemo.Business.Base;
using BackendDemo.Business.IServices;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.DTOs.Auth;
using BackendDemo.SharedLibrary.DTOs;

namespace BackendDemo.Business.Services;

public class AuthenticationService : BusinessService, IAuthenticationService
{
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;

    public AuthenticationService(IServiceProvider sp, ITokenService tokenService, IUserService userService) : base(sp)
    {
        _tokenService = tokenService;
        _userService = userService;
    }

    public async Task<AppResponse<TokenDTO>> CreateTokenAsync(LoginDTO loginDto)
    {
        if (loginDto == null)
            throw new ArgumentNullException(nameof(loginDto));

        if (String.IsNullOrEmpty(loginDto.FirsName) || String.IsNullOrEmpty(loginDto.LastName))
            throw new InvalidDataException(nameof(loginDto));

        var user = await _userService.GetUserByFirstNameAndLastName(loginDto.FirsName, loginDto.LastName);

        if (user == null)
            return new AppResponse<TokenDTO>("Kullanıcı bulunamadı", ResponseStatus.ERROR);

        return await _tokenService.CreateToken(Mapper.Map<UserDTO>(user));
    }
}
