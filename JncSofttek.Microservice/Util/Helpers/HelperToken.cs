using JncSofttek.Microservice.Common;
using JncSofttek.Microservice.Repository.Repositories.Dtos.User;
using JncSofttek.Microservice.Util.Helpers.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JncSofttek.Microservice.Util.Helpers
{
    public class HelperToken : IHelperToken
    {
        private readonly IConfiguration _config;
        public HelperToken(IConfiguration config) => _config = config;

        public string GenerateTokenJWTByUserInfo(UserDto user)
        {
            var _symmetricSecurityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config.GetValue<string>("JwtBearer:SecurityKey")));
            var _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var _header = new JwtHeader(_signingCredentials);
            var _claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Aud, _config.GetValue<string>("JwtBearer:Audience")),
                new Claim(JwtRegisteredClaimNames.Iss, _config.GetValue<string>("JwtBearer:Issuer")),
                new Claim(AppConsts.CLAIM_USER_EMAIL_ADDRESS, user.EmailAddress),
                new Claim(AppConsts.CLAIM_USER_ROLE, $"{user.Role}")
            };
            var _payload = new JwtPayload(
                issuer: _config.GetSection("JwtBearer:Issuer").Value,
                audience: _config.GetSection("JwtBearer:Audience").Value,
                claims: _claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(24)
            );
            var _token = new JwtSecurityToken(_header, _payload);
            return new JwtSecurityTokenHandler().WriteToken(_token);
        }
    }
}
