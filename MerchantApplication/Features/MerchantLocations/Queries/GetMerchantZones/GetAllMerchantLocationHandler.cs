using AutoMapper;
using MediatR;
using MerchantApplication.Features.MerchantLocations.Dto;
using MerchantApplication.Features.MerchantLocations.Interfaces;
using MerchantApplication.Features.MerchantLocations.Queries.GetMerchantZonesById;
using MerchantApplication.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.MerchantLocations.Queries.GetMerchantZones
{
    public class GetAllMerchantLocationHandler : IRequestHandler<GetAllMerchantLocationQuery,ApiResponse<IEnumerable<MerchantLocationDto>>>
    {
        private readonly IMerchantLocationRepository _merchantLocationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetMerchantZoneByIdHandler> _logger;

        public GetAllMerchantLocationHandler(IMerchantLocationRepository merchantLocationRepository, IMapper mapper, ILogger<GetMerchantZoneByIdHandler> logger)
        {
            _merchantLocationRepository = merchantLocationRepository;
            _mapper = mapper;
            _logger = logger;


        }
        public async Task<ApiResponse<IEnumerable<MerchantLocationDto>>> Handle(GetAllMerchantLocationQuery request,CancellationToken cancellationToken)
        {
            try
            {
                var locations = await _merchantLocationRepository.GetAllZonesAsync();
                if (locations == null)
                {
                    return ApiResponse<IEnumerable<MerchantLocationDto>>.Fail("0", "No Record");
                }
                var dtos = _mapper.Map<IEnumerable<MerchantLocationDto>>(locations);
                return ApiResponse<IEnumerable<MerchantLocationDto>>.Success(dtos);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error fetching merchant locations.");
                return ApiResponse<IEnumerable<MerchantLocationDto>>.Fail("0", "Error fetching merchant locations.");
            }
        }
    }
}
