using AutoMapper;
using MediatR;
using MerchantApplication.Features.Merchants.Dto;
using MerchantApplication.Shared;
using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantApplication.Interfaces;
namespace MerchantApplication.Features.Merchants.Commands.AddMerchant
{
    public class AddMerchantHandler : IRequestHandler<AddMerchantCommand, ApiResponse<MerchantDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMerchantRepository _merchantRepository;

        public AddMerchantHandler(
            IMapper mapper,
            IMerchantRepository merchantRepository)
        {
            _mapper = mapper;
            _merchantRepository = merchantRepository;
        }

        public async Task<ApiResponse<MerchantDto>> Handle(AddMerchantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var merchantEntity = _mapper.Map<Merchant>(request);
                if (merchantEntity == null)
                {
                    return ApiResponse<MerchantDto>.Fail("500", "Invalid merchant data.");
                }

                await _merchantRepository.AddAsync(merchantEntity);

                var merchantDto = _mapper.Map<MerchantDto>(merchantEntity);

                return ApiResponse<MerchantDto>.Success(merchantDto, "201", "Merchant added successfully.");
            }
            catch (Exception)
            {
                return ApiResponse<MerchantDto>.Fail("500", "An error occurred while adding the merchant.");
            }
        }
    }
}
