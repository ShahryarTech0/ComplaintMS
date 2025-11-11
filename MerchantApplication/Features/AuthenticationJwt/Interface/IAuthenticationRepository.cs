using MerchantApplication.Features.AuthenticationJwt.Dto;
using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.AuthenticationJwt.Interface
{
    //public interface IAuthenticationRepository
    //{
    //    Task<User?> RegisterAsync(UserDto userDto);

    //    Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenResponseDto userDto);
    //    Task<TokenResponseDto?> LoginAsync(UserDto userDto); // ✅ Make sure the method name and casing match exactly
    //}

    public interface IAuthenticationRepository
    {
        Task<User?> RegisterAsync(User user);
        Task<User?> RefreshTokenAsync(User user);
        Task<User?> LoginAsync(User user);
    }
}
