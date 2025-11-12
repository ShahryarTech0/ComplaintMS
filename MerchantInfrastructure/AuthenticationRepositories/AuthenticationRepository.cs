using MerchantApplication.Features.AuthenticationJwt.Dto;
using MerchantApplication.Features.AuthenticationJwt.Interface;
using MerchantCore.Entities;
using MerchantInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MerchantInfrastructure.AuthenticationRepositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // 🔹 Register user
        public async Task<User?> RegisterAsync(User user)
        {
            var existingUser = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == user.Username);

            if (existingUser != null)
                return null;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // 🔹 Login user
        public async Task<User?> LoginAsync(User user)
        {
            var userFromDb = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == user.Username);

            if (userFromDb == null)
                return null;

            // ⚠️ If you store password hashes, verify here (example)
            // if (!BCrypt.Net.BCrypt.Verify(user.Password, userFromDb.PasswordHash)) return null;

            return userFromDb;
        }

        // 🔹 Refresh Token (for regeneration)
        public async Task<User?> RefreshTokenAsync(User user)
        {
            var userFromDb = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (userFromDb == null) return null;

            userFromDb.RefreshToken = user.RefreshToken;
            userFromDb.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime;

            _context.Users.Update(userFromDb);
            await _context.SaveChangesAsync();

            return userFromDb;
        }

        // ✅ 🔹 Generate JWT Access Token
        public Task<string> GenerateAccessTokenAsync(User user)
        {
            var jwtSettings = _configuration.GetSection("AppSettings:Jwt");
            var keyString = jwtSettings["Key"];

            if (string.IsNullOrEmpty(keyString))
                throw new InvalidOperationException("JWT Key is missing from configuration. Check 'AppSettings:Jwt:Key' in appsettings.json");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
    {
        new Claim("UserID", user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role, user.Roles ?? "User")
    };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }


        // ✅ 🔹 Generate Refresh Token
        public Task<string> GenerateRefreshTokenAsync(User user)
        {
            var randomBytes = new byte[32];
            using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            var refreshToken = Convert.ToBase64String(randomBytes);
            return Task.FromResult(refreshToken);
        }
        public async Task<User?> GetUserByIdAndRefreshTokenAsync(int userId, string refreshToken)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId && u.RefreshToken == refreshToken);
        }

    }
}
