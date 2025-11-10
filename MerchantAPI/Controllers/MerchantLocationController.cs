using Azure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MerchantApplication.Features.MerchantLocations.Commands.AddMerchantLocation;
using MerchantApplication.Features.MerchantLocations.Queries.GetMerchantZonesById;
namespace MerchantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantLocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchantLocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Add Merchant Location
        [HttpPost("add")]
        public async Task<ActionResult> AddMerchantLocation([FromBody] AddMerchantLocationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

       
        // Get Zone Areas by ID
        [HttpGet("zones/{zoneId}")]
        public async Task<ActionResult> GetZoneAreas(int zoneId)
        {
            
            var result = await _mediator.Send(new GetMerchantZoneByIdQuery(zoneId));
            return Ok(result);
        }
    }
}
