using AutoMapper;
using MediatR;
using MerchantApplication.Features.AuthenticationJwt.Interface;
using MerchantApplication.Features.SignalR.Interface;
using MerchantApplication.Shared;
using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MerchantApplication.Features.AuthenticationJwt.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, ApiResponse<User>>
    {
        private readonly IAuthenticationRepository _repo;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        public RegisterUserHandler(IAuthenticationRepository repo,IMapper mapper,INotificationService notificationService)
        {
            _repo = repo;
            _mapper = mapper;
            _notificationService = notificationService;
        }


        public async Task<ApiResponse<User>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // 1️⃣ Map DTO -> User entity
            var userEntity = _mapper.Map<User>(request.UserDto);

            // 2️⃣ Hash the password manually (important!)
            userEntity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.UserDto.Password);

            // 3️⃣ Save user in DB
            var registeredUser = await _repo.RegisterAsync(userEntity);

            if (registeredUser == null)
                return ApiResponse<User>.Fail("0", "Username already exists");

            // 4️⃣ Create a notification
            var notification = new Notification
            {
                Title = "User Registered",
                Message = $"User '{registeredUser.Username}' registered successfully.",
                OccurredAt = DateTimeOffset.UtcNow
            };

            // 5️⃣ Send notification through SignalR
            await _notificationService.NotifyAllAsync(notification);

            // 6️⃣ Return successful API response
            return ApiResponse<User>.Success(registeredUser);
        }
    }
}
