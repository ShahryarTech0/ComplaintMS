using AutoMapper;
using MediatR;
using MerchantApplication.Features.MerchantLocations.Commands.AddMerchantLocation;
using MerchantApplication.Features.MerchantLocations.Dto;
using MerchantApplication.Features.MerchantLocations.Interfaces;
using MerchantApplication.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.MerchantLocations.Commands.UpdateMerchantLocation
{
    public class UpdateMerchantLocationHandler : IRequestHandler<UpdateMerchantLocationCommand,ApiResponse<MerchantLocationDto>>
    {

        private readonly IMerchantLocationRepository _repositoryLocationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddMerchantLocationHandler> _logger;

        public UpdateMerchantLocationHandler(IMerchantLocationRepository repositoryLocationRepository, IMapper mapper, ILogger<AddMerchantLocationHandler> logger)
        {
            _repositoryLocationRepository = repositoryLocationRepository;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<ApiResponse<MerchantLocationDto>> Handle(UpdateMerchantLocationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingLocation = await _repositoryLocationRepository.GetZoneByID(request.ID);
                if (existingLocation == null)
                {
                    _logger.LogWarning("Merchant location not found for update. Id={Id}", request.ID);
                    return ApiResponse<MerchantLocationDto>.Fail("0", $"Merchant location with ID {request.ID} not found.");
                }

                // Map updated fields from the command to the entity
                _mapper.Map(request, existingLocation);

                // Optional: handle logical conditions if needed
                if (request.IsDeleted)
                {
                    existingLocation.Status = "Inactive";
                }

                var result=await _repositoryLocationRepository.UpdateZoneAsync(existingLocation);
                _logger.LogInformation("Merchant location with ID {Id} updated successfully.", request.ID);

                var dto =_mapper.Map<MerchantLocationDto>(result);
                return ApiResponse<MerchantLocationDto>.Success(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating merchant location ID {Id}", request.ID);
                return ApiResponse<MerchantLocationDto>.Fail("0", $"Error updating merchant location: {ex.Message}");
            }
        }
    }
}
