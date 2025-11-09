using AutoMapper;
using MerchantApplication.Features.Merchants.Dto;
using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantApplication.Features.Merchants.Commands.AddMerchant;
namespace MerchantApplication.Features.Merchants.Mapping
{
    public class MerchantMappingProfile : Profile
    {
        public MerchantMappingProfile()
        {
            CreateMap<AddMerchantCommand, Merchant>();
            CreateMap<Merchant, MerchantDto>();
        }
    }
}
