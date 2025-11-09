using MediatR;
using MerchantApplication.Features.Merchants.Dto;
using MerchantApplication.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Commands.AddMerchant
{
        public record AddMerchantCommand(string MerchantName, string MerchantAddress, string? Email, string? OtherEmail, string? Number, string? OtherNumber, string City, int Zone, int Area, string? MerchantCode) : IRequest<ApiResponse<MerchantDto>>;
    
}
