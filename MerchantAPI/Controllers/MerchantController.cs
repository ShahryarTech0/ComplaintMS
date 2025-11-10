using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MerchantApplication.Features.Merchants.Commands.AddMerchant;
using MerchantApplication.Features.Merchants.Queries.GetMerchantById;
using MerchantApplication.Features.Merchants.Commands.UpdateMerchant;
using MerchantApplication.Features.Merchants.Commands.DeleteMerchant;
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

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddMerchantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetMerchantByIdQuery(id));
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateMerchant(UpdateMerchantCommand command)
        {

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerchant(int id)
        {
            var result = await _mediator.Send(new DeleteMerchantCommand(id));
            return Ok(result);
        }
    }
}
