namespace JWTCQRSProject.Api.Infrastructure.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string Key = "SecurityKey---1.";
        public const int Expire = 5;
    }
}
