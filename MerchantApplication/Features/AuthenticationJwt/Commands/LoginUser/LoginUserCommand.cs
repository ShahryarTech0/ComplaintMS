using MediatR;
using MerchantApplication.Features.AuthenticationJwt.Dto;
using MerchantApplication.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.AuthenticationJwt.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<ApiResponse<TokenResponseDto>>
    {
        public UserDto UserDto { get; set; }

        public LoginUserCommand(UserDto userDto)
        {
            UserDto = userDto;
        }
    }
}
