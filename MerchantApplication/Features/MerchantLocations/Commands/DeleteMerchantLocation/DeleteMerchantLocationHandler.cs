using AutoMapper;
using MediatR;
using MerchantApplication.Features.MerchantLocations.Dto;
using MerchantApplication.Features.MerchantLocations.Interfaces;
using MerchantApplication.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.MerchantLocations.Commands.DeleteMerchantLocation
{
    public class DeleteMerchantLocationHandler : IRequestHandler<DeleteMerchantLocationCommand ,ApiResponse<string>>
    {
        private readonly IMapper _mapper;
        private readonly IMerchantLocationRepository _merchantLocationRepository;
        private readonly ILogger<DeleteMerchantLocationHandler> _logger;
        public DeleteMerchantLocationHandler(IMapper mapper, IMerchantLocationRepository merchantLocationRepository, ILogger<DeleteMerchantLocationHandler> logger)
        {
            _mapper = mapper;
            _merchantLocationRepository = merchantLocationRepository;
            _logger = logger;
        }
        public async Task<ApiResponse<string>> Handle(DeleteMerchantLocationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _merchantLocationRepository.GetZoneByID(request.id);
                if (result == null)
                {
                    _logger.LogWarning("Location not found for deletion. Id={Id}", request.id);
                    return ApiResponse<string>.Fail("0", $"Location with id {request.id} not found.");
                }
                // Option A: Hard delete
                await _merchantLocationRepository.SoftDeleteAsync(result);

                // Option B: Soft delete
                // await _merchantLocationRepository.SoftDeleteAsync(result);

                _logger.LogInformation("Merchant Location with ID {Id} deleted successfully.", request.id);
                return ApiResponse<string>.Success($"Merchant Location with ID {request.id} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting Merchant Location with ID {Id}", request.id);
                return ApiResponse<string>.Fail("0", "An error occurred while deleting the location.");
            }
        }
        }
}
