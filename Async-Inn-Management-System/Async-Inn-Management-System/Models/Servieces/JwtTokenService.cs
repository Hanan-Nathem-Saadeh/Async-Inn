﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Servieces
{
    public class JwtTokenService
    {
        private SignInManager<ApplicationUser> signInManager;
        private IConfiguration configration;
        public JwtTokenService(IConfiguration configration, SignInManager<ApplicationUser> signInManager)
        {
            this.configration = configration;
            this.signInManager=signInManager;

        }
        public static TokenValidationParameters GetValidationParameters(IConfiguration configuration )
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                // This Is Our main goal: Make sure the security key, which comes from configuration is valid
                IssuerSigningKey = GetSecurityKey(configuration),

                // For simplifying testing
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        }

        private static SecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secret = configuration["JWT:Secret"];
            if (secret == null) { throw new InvalidOperationException("JWT:Secret is midding"); }
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            return new SymmetricSecurityKey(secretBytes);
        }
        public async Task<string> GetToken(ApplicationUser user, TimeSpan expiresIn)
        {
            var principal = await signInManager.CreateUserPrincipalAsync(user);
            if (principal == null) { return null; }

            var signingKey = GetSecurityKey(configration);
            var token = new JwtSecurityToken(
              expires: DateTime.UtcNow + expiresIn,
              signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
              claims: principal.Claims
             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
