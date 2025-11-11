using MediatR;
using MerchantApplication.Features.AuthenticationJwt.Dto;
using MerchantApplication.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.AuthenticationJwt.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<ApiResponse<TokenResponseDto>>
    {
        public RefreshTokenResponseDto RefreshDto { get; set; }

        public RefreshTokenCommand(RefreshTokenResponseDto dto)
        {
            RefreshDto = dto;
        }
    }
}
