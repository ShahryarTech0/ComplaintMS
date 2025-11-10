using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantApplication.Shared;
using MerchantApplication.Features.Merchants.Dto;
namespace MerchantApplication.Features.Merchants.Commands.UpdateMerchant
{
    public record UpdateMerchantCommand(int ID, string MerchantName, string MerchantAddress, string? Email, string? OtherEmail, string? Number, string? OtherNumber, string City, int Zone, int Area) : IRequest<ApiResponse<MerchantDto>>;
}
