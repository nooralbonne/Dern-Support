﻿using Dern_Support.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Dern_Support.Repositories.Services
{
    public class JwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public JwtTokenService(IConfiguration configuration, SignInManager<ApplicationUser> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public static TokenValidationParameters ValidateToken(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(configuration),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                ClockSkew = TimeSpan.Zero // Optional: Remove clock skew allowance

            };
        }
        private static SecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secretKey = configuration["JWT:SecretKey"];
            if (secretKey == null)
            {
                throw new InvalidOperationException("Jwt Secret key is not exsist");
            }

            var secretBytes = Encoding.UTF8.GetBytes(secretKey);
            return new SymmetricSecurityKey(secretBytes);
        }
        public async Task<string> GenerateToken(ApplicationUser user, TimeSpan expiryDate)
        {
            var userPrincliple = await _signInManager.CreateUserPrincipalAsync(user);
            if (userPrincliple == null)
            {
                return null;
            }

            var signInKey = GetSecurityKey(_configuration);

            var token = new JwtSecurityToken
                (
                expires: DateTime.UtcNow + expiryDate,
                signingCredentials: new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256),
                claims: userPrincliple.Claims
                );

            // Log the generated token
            Console.WriteLine($"Generated Token: {token}");

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
