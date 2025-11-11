using MediatR;
using MerchantApplication.Features.AuthenticationJwt.Interface;
using MerchantApplication.Shared;
using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace MerchantApplication.Features.AuthenticationJwt.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, ApiResponse<User>>
    {
        private readonly IAuthenticationRepository _repo;
        private readonly IMapper _mapper;
        public RegisterUserHandler(IAuthenticationRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<ApiResponse<User>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<User>(request.UserDto);

            var registeredUser = await _repo.RegisterAsync(userEntity);

            if (registeredUser == null)
                return ApiResponse<User>.Fail("0", "Username already exists");

            return ApiResponse<User>.Success(registeredUser);
        }
    }
}
