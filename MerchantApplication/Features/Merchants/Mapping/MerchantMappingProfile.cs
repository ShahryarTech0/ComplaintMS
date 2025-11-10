using AutoMapper;
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
namespace MerchantApplication.Features.Merchants.Mapping
{
    public class MerchantMappingProfile : Profile
    {
        public MerchantMappingProfile()
        {
            CreateMap<AddMerchantCommand, Merchant>();
            CreateMap<UpdateMerchantCommand, Merchant>();

            // ✅ Create mappings for Delete (if needed)
            // Usually Delete only needs MerchantId, but we can still define it
            CreateMap<DeleteMerchantCommand, Merchant>();
            CreateMap<Merchant, MerchantDto>();
        }
    }
}
