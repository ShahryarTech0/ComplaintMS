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

        public AuthenticationRepository(AppDbContext context)
        {
            _context = context;
        }

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

        public async Task<User?> RefreshTokenAsync(User user)
        {
            var userFromDb = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == user.Id);

            if (userFromDb == null) return null;

            userFromDb.RefreshToken = user.RefreshToken;
            userFromDb.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime;

            _context.Users.Update(userFromDb);
            await _context.SaveChangesAsync();

            return userFromDb;
        }

        public async Task<User?> LoginAsync(User user)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == user.Username);
        }
    }
}
