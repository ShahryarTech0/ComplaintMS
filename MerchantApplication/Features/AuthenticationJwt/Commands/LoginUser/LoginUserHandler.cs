using MediatR;
using MerchantApplication.Features.AuthenticationJwt.Dto;
using MerchantApplication.Features.AuthenticationJwt.Interface;
using MerchantApplication.Shared;
using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace MerchantApplication.Features.AuthenticationJwt.Commands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, ApiResponse<TokenResponseDto>>
    {
        private readonly IAuthenticationRepository _repo;
        private readonly IMapper _mapper;
        public LoginUserHandler(IAuthenticationRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<TokenResponseDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Map UserDto -> User entity
            var userEntity = _mapper.Map<User>(request.UserDto);

            // Check login
            var userFromDb = await _repo.LoginAsync(userEntity);

            if (userFromDb == null)
                return ApiResponse<TokenResponseDto>.Fail("0", "Invalid username or password");

            // Map user entity to TokenResponseDto
            var tokenDto = _mapper.Map<TokenResponseDto>(userFromDb);

            return ApiResponse<TokenResponseDto>.Success(tokenDto);
        }
    }
}
