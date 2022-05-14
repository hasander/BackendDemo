namespace BackendDemo.Core.DTOs.Auth;

public class RefreshTokenDTO
{
    public int UserId { get; set; }
    public string? RefreshToken { get; set; }
}
