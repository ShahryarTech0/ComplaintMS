using Azure;
using MediatR;
using MerchantApplication.Features.MerchantLocations.Commands.AddMerchantLocation;
using MerchantApplication.Features.MerchantLocations.Commands.DeleteMerchantLocation;
using MerchantApplication.Features.MerchantLocations.Commands.UpdateMerchantLocation;
using MerchantApplication.Features.MerchantLocations.Queries.GetMerchantZones;
using MerchantApplication.Features.MerchantLocations.Queries.GetMerchantZonesById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> AddMerchantLocation([FromBody] AddMerchantLocationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

       
        // Get Zone Areas by ID
        [HttpGet("zones/{zoneId}")]
        public async Task<IActionResult> GetZoneAreas(int zoneId)
        {
            
            var result = await _mediator.Send(new GetMerchantZoneByIdQuery(zoneId));
            return Ok(result);
        }

        //// Update Merchant Location
        [HttpPut("update")]
        public async Task<IActionResult> UpdateMerchantLocation([FromBody] UpdateMerchantLocationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //// Delete Merchant Location
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMerchantLocation(int id)
        {
            var result = await _mediator.Send(new DeleteMerchantLocationCommand(id));
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllMerchantLocations()
        {
            var result = await _mediator.Send(new GetAllMerchantLocationQuery());
            return Ok(result);
        }

    }
}
