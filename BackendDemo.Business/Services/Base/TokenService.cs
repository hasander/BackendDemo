using BackendDemo.Business.Base;
using BackendDemo.Business.IServices;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.DTOs.Auth;
using BackendDemo.Core.Entities;
using BackendDemo.SharedLibrary.Configurations;
using BackendDemo.SharedLibrary.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Datamedia.Business.Services;

public class TokenService : BusinessService, ITokenService
{
    private readonly IUserService _userService;
    private readonly CustomTokenOptions _customTokenOptions;

    public TokenService(IServiceProvider sp, IUserService userService, IOptions<CustomTokenOptions> customTokenOptions):base(sp)
    {
        _customTokenOptions = customTokenOptions.Value;
        _userService = userService;
    } 

    public async Task<AppResponse<TokenDTO>> CreateToken(UserDTO user)
    {
        var accessTokenExpiration = DateTime.Now.AddMinutes(_customTokenOptions.AccessTokenExpiration);

        // Authentication(Yetkilendirme) başarılı ise JWT token üretilir.
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_customTokenOptions.SecurityKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim("ID", user.ID.ToString()),
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenaa = tokenHandler.CreateToken(tokenDescriptor);

        var tokenDto = new TokenDTO
        {
            AccessToken = tokenHandler.WriteToken(tokenaa),
            AccesTokenExpirationDate = accessTokenExpiration,
        };
         
         

        return new AppResponse<TokenDTO>(tokenDto, ResponseStatus.SUCCESS);
    }

   
}
