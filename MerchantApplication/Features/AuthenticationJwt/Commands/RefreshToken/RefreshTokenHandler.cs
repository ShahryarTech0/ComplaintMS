using AutoMapper;
using AutoMapper;
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
namespace MerchantApplication.Features.AuthenticationJwt.Commands.RefreshToken
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, ApiResponse<TokenResponseDto>>
    {
        private readonly IAuthenticationRepository _repo;
        private readonly IMapper _mapper;
        public RefreshTokenHandler(IAuthenticationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<ApiResponse<TokenResponseDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            // Map RefreshTokenResponseDto -> User entity
            var userEntity = _mapper.Map<User>(request.RefreshDto);

            var updatedUser = await _repo.RefreshTokenAsync(userEntity);

            if (updatedUser == null)
                return ApiResponse<TokenResponseDto>.Fail("0", "Invalid refresh token");

            var tokenDto = _mapper.Map<TokenResponseDto>(updatedUser);

            return ApiResponse<TokenResponseDto>.Success(tokenDto);
        }
    }
}
