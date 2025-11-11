using MediatR;
using MerchantApplication.Features.AuthenticationJwt.Commands.LoginUser;
using MerchantApplication.Features.AuthenticationJwt.Commands.RefreshToken;
using MerchantApplication.Features.AuthenticationJwt.Commands.RegisterUser;
using MerchantApplication.Features.AuthenticationJwt.Dto;
using MerchantApplication.Features.AuthenticationJwt.Interface;
using MerchantCore.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace MerchantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            var result = await _mediator.Send(new RegisterUserCommand(userDto));
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            var result = await _mediator.Send(new LoginUserCommand(userDto));
            return Ok(result);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenResponseDto refreshDto)
        {
            var result = await _mediator.Send(new RefreshTokenCommand(refreshDto));
            return Ok(result);

        }
    }
}