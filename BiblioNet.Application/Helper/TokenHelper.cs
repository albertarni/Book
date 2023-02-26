using BiblioNet.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Timesheet.Core.Models;

namespace Timesheet.Application.Helper
{
    internal static class TokenHelper
    {
        internal static RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                ExpireDate = DateTime.Now.AddDays(7),
                CreatedDate = DateTime.Now
            };
            return refreshToken;


        }

        internal static void SetRefreshToken(RefreshToken refreshToken, Employee employee, HttpResponse response)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.ExpireDate

            };

            response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
            employee.refreshToken.Token = refreshToken.Token;
            employee.refreshToken.ExpireDate = refreshToken.ExpireDate;
            employee.refreshToken.CreatedDate = refreshToken.CreatedDate;
        }
        internal static string CreateToken(Employee employee, IConfiguration configuration)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, employee.UserName),
                new Claim(ClaimTypes.Role,employee.Type)
            };


            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
