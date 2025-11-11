using MediatR;
using MerchantApplication.Features.AuthenticationJwt.Dto;
using MerchantApplication.Shared;
using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.AuthenticationJwt.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<ApiResponse<User>>
    {
        public UserDto UserDto { get; set; }

        public RegisterUserCommand(UserDto userDto)
        {
            UserDto = userDto;
        }
    }
}
