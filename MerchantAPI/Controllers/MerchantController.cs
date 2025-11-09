using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MerchantApplication.Features.Merchants.Commands.AddMerchant;
using MerchantApplication.Features.Merchants.Queries.GetMerchantById;
namespace MerchantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MerchantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("test-mapping")]
        public async Task<IActionResult> Add(AddMerchantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetMerchantByIdQuery(id));
            return Ok(result);
        }
    }
}
