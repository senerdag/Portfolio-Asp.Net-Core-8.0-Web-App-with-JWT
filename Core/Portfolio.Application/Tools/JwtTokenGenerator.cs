using Microsoft.IdentityModel.Tokens;
using Portfolio.Application.Dtos;
using Portfolio.Application.Features.Mediator.Results.AppUserResult;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(GetCheckAppUserQueryResult result) 
        { 
            var claims=new List<Claim>();

            if(!string.IsNullOrWhiteSpace(result.Role))
            claims.Add(new Claim(ClaimTypes.Role,result.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));

            if(!string.IsNullOrWhiteSpace(result.Username))
                claims.Add(new Claim("Username",result.Username));

            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefault.Key));
            
            var signinCredentials=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var expireDate=DateTime.UtcNow.AddDays(JwtTokenDefault.Expire);

            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefault.ValidIssuer, audience: JwtTokenDefault.ValidAudience,
                claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signinCredentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return new TokenResponseDto(tokenHandler.WriteToken(token),expireDate);
        }
    }
}
