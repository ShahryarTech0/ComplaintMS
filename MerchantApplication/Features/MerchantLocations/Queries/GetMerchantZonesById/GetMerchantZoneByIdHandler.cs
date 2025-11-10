using AutoMapper;
using MediatR;
using MerchantApplication.Features.MerchantLocations.Dto;
using MerchantApplication.Features.MerchantLocations.Interfaces;
using MerchantApplication.Features.Merchants.Dto;
using MerchantApplication.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MerchantApplication.Features.MerchantLocations.Queries.GetMerchantZonesById
{
    public class GetMerchantZoneByIdHandler : IRequestHandler<GetMerchantZoneByIdQuery,ApiResponse<MerchantLocationDto>>
    {
        private readonly IMerchantLocationRepository _merchantLocationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetMerchantZoneByIdHandler> _logger;

        public GetMerchantZoneByIdHandler(IMerchantLocationRepository merchantLocationRepository, IMapper mapper, ILogger<GetMerchantZoneByIdHandler> logger)
        {
            _merchantLocationRepository= merchantLocationRepository;
             _mapper = mapper;
            _logger = logger;


        }
        public async Task<ApiResponse<MerchantLocationDto>> Handle(GetMerchantZoneByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Get areas from repository
                var zones = await _merchantLocationRepository.GetZoneByID(request.Id);

                if (zones == null)
                {
                    _logger.LogInformation("Areas not found for Zone ID {ZoneID}", request.Id);
                    return ApiResponse<MerchantLocationDto>.Fail("0", "Invalid merchantLocation data");
                }

                _logger.LogInformation("Areas fetched successfully for Zone ID {ZoneID}", request.Id);
                var dto= _mapper.Map<MerchantLocationDto>(zones);
                return ApiResponse<MerchantLocationDto>.Success(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching areas for Zone ID {ZoneID}", request.Id);
                return ApiResponse<MerchantLocationDto>.Fail("400", "An error occurred while Getting the merchantlocation.");
            }
        }

    }
}
