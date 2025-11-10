using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantApplication.Interfaces;
using MerchantApplication.Shared;
using AutoMapper;
namespace MerchantApplication.Features.Merchants.Commands.DeleteMerchant
{
    public class DeleteMerchantHandler : IRequestHandler<DeleteMerchantCommand, ApiResponse<string>>
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;
        public DeleteMerchantHandler(IMerchantRepository merchantRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;   
        }
        public async Task<ApiResponse<string>> Handle(DeleteMerchantCommand request, CancellationToken cancellationToken)
        {
            var result = await _merchantRepository.GetByIdAsync(request.ID);
            if (result == null)
            {
                return ApiResponse<string>.Fail("404", "Merchant not found.");
            }
            await _merchantRepository.DeleteAsync(result);
            return ApiResponse<string>.Success("Merchant deleted successfully.");
        }
    }
}
