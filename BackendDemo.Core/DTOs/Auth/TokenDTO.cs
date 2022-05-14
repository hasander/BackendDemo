namespace BackendDemo.Core.DTOs.Auth;

public class TokenDTO
{
    public string AccessToken { get; set; } = default!;
    public DateTime AccesTokenExpirationDate { get; set; }
    public string RefreshToken { get; set; } = default!;
    public DateTime RefreshTokenExpirationDate { get; set; }
}
