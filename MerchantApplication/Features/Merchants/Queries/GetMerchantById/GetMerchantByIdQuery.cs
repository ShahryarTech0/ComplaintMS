using MediatR;
using MerchantApplication.Features.Merchants.Dto;
using MerchantApplication.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Queries.GetMerchantById
{
    public record GetMerchantByIdQuery(int Id) : IRequest<ApiResponse<MerchantDto>>;
}
