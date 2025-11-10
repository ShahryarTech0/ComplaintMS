using MediatR;
using MerchantApplication.Interfaces;
using MerchantApplication.Shared;
using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantApplication.Features.Merchants.Dto;
using MerchantApplication.Features.Merchants.Mapping;
using AutoMapper;
namespace MerchantApplication.Features.Merchants.Commands.UpdateMerchant
{
    public class UpdateMerchantHandler : IRequestHandler<UpdateMerchantCommand, ApiResponse<MerchantDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMerchantRepository _merchantRepository;
        public UpdateMerchantHandler(IMerchantRepository merchantRepository, IMapper mapper)
        {
             _mapper = mapper;
            _merchantRepository = merchantRepository;


        }
        public async Task<ApiResponse<MerchantDto>> Handle(UpdateMerchantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingMerchant = await _merchantRepository.GetByIdAsync(request.ID);
                if (existingMerchant == null)
                    return ApiResponse<MerchantDto>.Fail("0", "Merchant not found.");

                // ✅ Step 2: Map updated values onto tracked entity
                _mapper.Map(request, existingMerchant);

                // ✅ Step 3: Save changes
                await _merchantRepository.UpdateAsync(existingMerchant);

                // ✅ Step 4: Map to DTO for response
                var responseDto = _mapper.Map<MerchantDto>(existingMerchant);

                return ApiResponse<MerchantDto>.Success(responseDto);
            }
            catch (Exception)
            {
                return ApiResponse<MerchantDto>.Fail("400", "An error occurred while adding the merchant.");
            }

        }
    }
}
