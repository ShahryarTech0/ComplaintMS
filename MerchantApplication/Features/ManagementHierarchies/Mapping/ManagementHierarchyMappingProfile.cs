using AutoMapper;
using MerchantApplication.Features.ManagementHierarchies.Commands.AddManagementHierarchy;
using MerchantApplication.Features.ManagementHierarchies.Dto;
using MerchantApplication.Features.Merchants.Commands.AddMerchant;
using MerchantApplication.Features.Merchants.Commands.DeleteMerchant;
using MerchantApplication.Features.Merchants.Commands.UpdateMerchant;
using MerchantApplication.Features.Merchants.Dto;
using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.ManagementHierarchies.Mapping
{
    public class ManagementHierarchyMappingProfile : Profile
    {
        public ManagementHierarchyMappingProfile()
        {
            CreateMap<AddManagementHierarchyCommand, ManagementHierarchy>().ReverseMap();
            //CreateMap<UpdateMerchantCommand, Merchant>().ReverseMap();
            //CreateMap<DeleteMerchantCommand, Merchant>().ReverseMap();
            CreateMap<ManagementHierarchy, ManagementHierarchyDto>();
        }
    }
}
