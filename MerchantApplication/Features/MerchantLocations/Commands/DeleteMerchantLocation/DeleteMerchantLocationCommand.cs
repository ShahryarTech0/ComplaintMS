using MediatR;
using MerchantApplication.Features.MerchantLocations.Dto;
using MerchantApplication.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.MerchantLocations.Commands.DeleteMerchantLocation
{
    public record DeleteMerchantLocationCommand(int id) : IRequest<ApiResponse<string>>;
}
