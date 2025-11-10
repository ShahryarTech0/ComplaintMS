using AutoMapper;
using MediatR;
using MerchantApplication.Features.Merchants.Dto;
using MerchantApplication.Interfaces;
using MerchantApplication.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Queries.GetMerchantById
{
    public class GetMerchantByIdHandler : IRequestHandler<GetMerchantByIdQuery, ApiResponse<MerchantDto>>
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;

        public GetMerchantByIdHandler(IMerchantRepository merchantRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<MerchantDto>> Handle(GetMerchantByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var merchant = await _merchantRepository.GetByIdAsync(request.Id);
                if (merchant == null)
                {
                    return ApiResponse<MerchantDto>.Fail("0", "Merchant not found.");
                }

                var dto = _mapper.Map<MerchantDto>(merchant);
                return ApiResponse<MerchantDto>.Success(dto, "200", "Merchant retrieved successfully.");
            }
            catch (Exception)
            {
                return ApiResponse<MerchantDto>.Fail("400", "An error occurred while adding the merchant.");
            }
        }
    }
}
