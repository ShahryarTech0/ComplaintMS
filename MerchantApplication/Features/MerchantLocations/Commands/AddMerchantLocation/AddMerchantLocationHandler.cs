using AutoMapper;
using MediatR;
using MerchantApplication.Features.MerchantLocations.Dto;
using MerchantApplication.Shared;
using MerchantCore.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantApplication.Features.MerchantLocations.Commands.AddMerchantLocation;
using MerchantApplication.Features.MerchantLocations.Interfaces;
namespace MerchantApplication.Features.MerchantLocations.Commands.AddMerchantLocation
{
    public class AddMerchantLocationHandler : IRequestHandler<AddMerchantLocationCommand, ApiResponse<MerchantLocationDto>>
    {
        private readonly IMerchantLocationRepository _repositoryLocationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddMerchantLocationHandler> _logger;

        public AddMerchantLocationHandler(IMerchantLocationRepository repositoryLocationRepository, IMapper mapper, ILogger<AddMerchantLocationHandler> logger)
        {
            _repositoryLocationRepository = repositoryLocationRepository;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<ApiResponse<MerchantLocationDto>> Handle(AddMerchantLocationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Map command to entity
                var merchantLocation = _mapper.Map<MerchantLocation>(request);


                // Optional: validate ParentID
                if (merchantLocation.ParentID.HasValue && merchantLocation.ParentID.Value > 0) // 1 and 1>0
                {
                    var parentZone = await _repositoryLocationRepository.GetZoneByID(merchantLocation.ParentID.Value);//Parent location is null
                    if (parentZone == null)
                    {
                        _mapper.Map<MerchantLocationDto>(merchantLocation);

                        return ApiResponse<MerchantLocationDto>.Fail("0", "ParentId Doesnot Exist merchantlocation Location");

                    }
                }

                // Set defaults
                merchantLocation.Status = "Active";
                merchantLocation.isDeleted = false;

                // Add location
                var addedLocation = await _repositoryLocationRepository.AddZoneAsync(merchantLocation);
                var result = _mapper.Map<MerchantLocationDto>(merchantLocation);
                return ApiResponse<MerchantLocationDto>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding merchant location.");
                return ApiResponse<MerchantLocationDto>.Fail("0", "An error occurred while adding the merchantLocation.");
            }
        }
    }
}
