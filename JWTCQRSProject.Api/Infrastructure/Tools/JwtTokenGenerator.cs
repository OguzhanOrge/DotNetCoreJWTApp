using JWTCQRSProject.Api.Core.Application.Dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTCQRSProject.Api.Infrastructure.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(CheckUserResponseDto dto)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrEmpty(dto.Role)) 
                claims.Add(new Claim(ClaimTypes.Role, dto.Role));
            if(!string.IsNullOrEmpty(dto.Username))   
                claims.Add(new Claim("Username", dto.Username));
            claims.Add(new Claim(ClaimTypes.NameIdentifier,dto.Id.ToString()));

            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer:JwtTokenDefaults.ValidIssuer,audience:JwtTokenDefaults.ValidAudience,claims:claims,notBefore:DateTime.UtcNow,expires:DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire), signingCredentials:signingCredentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new TokenResponseDto(handler.WriteToken(jwtSecurityToken), expireDate);
        }
    }
}
