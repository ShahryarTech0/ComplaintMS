using MediatR;
using MerchantApplication.Features.ManagementHierarchies.Dto;
using MerchantApplication.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.ManagementHierarchies.Commands.AddManagementHierarchy
{
    public record AddManagementHierarchyCommand(string POCName, string Name, string POCEmail, string POCNumber, string OtherEmail, string OtherContact, string Address, int? ParentID, int ManagementType) : IRequest<ApiResponse<ManagementHierarchyDto>>;
}
