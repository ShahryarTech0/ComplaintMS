using AutoMapper;
using MediatR;
using MerchantApplication.Features.AuthenticationJwt.Dto;
using MerchantApplication.Features.AuthenticationJwt.Interface;
using MerchantApplication.Features.SignalR.Interface;
using MerchantApplication.Shared;
using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MerchantApplication.Features.AuthenticationJwt.Commands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, ApiResponse<TokenResponseDto>>
    {
        private readonly IAuthenticationRepository _repo;
        private readonly IMapper _mapper;
        private readonly INotificationService notification;
        public LoginUserHandler(IAuthenticationRepository repo, IMapper mapper, INotificationService notificationService)
        {
            _repo = repo;
            _mapper = mapper;
            notification = notificationService;
        }

        public async Task<ApiResponse<TokenResponseDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Map UserDto -> User entity
            var userEntity = _mapper.Map<User>(request.UserDto);

            // Validate login
            var userFromDb = await _repo.LoginAsync(userEntity);
            if (userFromDb == null)
                return ApiResponse<TokenResponseDto>.Fail("0", "Invalid username or password");

            // ✅ Generate JWT tokens here instead of using AutoMapper
            var accessToken = await _repo.GenerateAccessTokenAsync(userFromDb);   // Implemented in your repo
            var refreshToken = await _repo.GenerateRefreshTokenAsync(userFromDb); // Implemented in your repo


            // Store refresh token in DB
            userFromDb.RefreshToken = refreshToken;
            userFromDb.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _repo.RefreshTokenAsync(userFromDb);
            // ✅ Create TokenResponseDto manually
            var tokenDto = new TokenResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserId = userFromDb.Id,
                Username = userFromDb.Username
            };

            // ✅ Send SignalR Notification safely
            var notify = new Notification
            {
                Title = "Login Successful",
                Message = $"{userFromDb.Username} has logged in successfully",
                OccurredAt = DateTimeOffset.UtcNow
            };

            await this.notification.NotifyAllAsync(notify);
            // ✅ Return proper response
            return ApiResponse<TokenResponseDto>.Success(tokenDto);
        }
    }
}
