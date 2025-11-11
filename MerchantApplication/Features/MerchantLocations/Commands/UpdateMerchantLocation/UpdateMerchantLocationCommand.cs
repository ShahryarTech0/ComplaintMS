using MediatR;
using MerchantApplication.Features.MerchantLocations.Dto;
using MerchantApplication.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.MerchantLocations.Commands.UpdateMerchantLocation
{
    public record UpdateMerchantLocationCommand(int ID, string Name, int? ParentID, string? POCName, string? POCEmail, string? POCNumber, string? Address, string? OtherEmail, string? OtherContact, bool IsDeleted) : IRequest<ApiResponse<MerchantLocationDto>>;
}
