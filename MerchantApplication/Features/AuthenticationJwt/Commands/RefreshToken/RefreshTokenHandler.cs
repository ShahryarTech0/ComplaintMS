using MediatR;
using MerchantApplication.Features.AuthenticationJwt.Dto;
using MerchantApplication.Features.AuthenticationJwt.Interface;
using MerchantApplication.Shared;
using MerchantCore.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MerchantApplication.Features.AuthenticationJwt.Commands.RefreshToken
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, ApiResponse<TokenResponseDto>>
    {
        private readonly IAuthenticationRepository _repo;

        public RefreshTokenHandler(IAuthenticationRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<TokenResponseDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            // 1️⃣ Fetch user from DB by userId and refresh token
            var userFromDb = await _repo.GetUserByIdAndRefreshTokenAsync(request.RefreshDto.UserId, request.RefreshDto.RefreshToken);

            if (userFromDb == null)
                return ApiResponse<TokenResponseDto>.Fail("0", "Invalid refresh token");

            // 2️⃣ Generate new access token and refresh token
            var newAccessToken = await _repo.GenerateAccessTokenAsync(userFromDb);
            var newRefreshToken = await _repo.GenerateRefreshTokenAsync(userFromDb);

            // 3️⃣ Save new refresh token in DB
            userFromDb.RefreshToken = newRefreshToken;
            userFromDb.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7); // example expiry
            await _repo.RefreshTokenAsync(userFromDb);

            // 4️⃣ Return tokens
            var tokenDto = new TokenResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                UserId = userFromDb.Id,
                Username = userFromDb.Username
            };

            return ApiResponse<TokenResponseDto>.Success(tokenDto);
        }
    }
}
