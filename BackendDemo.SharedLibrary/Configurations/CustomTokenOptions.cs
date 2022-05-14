namespace BackendDemo.SharedLibrary.Configurations;

public class CustomTokenOptions
{
    public List<string> Audiences { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public int AccessTokenExpiration { get; set; }
    public int RefreshTokenExpiration { get; set; }
    public string SecurityKey { get; set; } = default!;
}
