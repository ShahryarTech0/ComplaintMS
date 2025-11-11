using AutoMapper;
using MerchantApplication.Features.MerchantLocations.Commands.AddMerchantLocation;
using MerchantApplication.Features.MerchantLocations.Commands.DeleteMerchantLocation;
using MerchantApplication.Features.MerchantLocations.Commands.UpdateMerchantLocation;
using MerchantApplication.Features.MerchantLocations.Dto;
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
namespace MerchantApplication.Features.MerchantLocations.Mapping
{
    public class MerchantLocationMappingProfile : Profile
    {
        public MerchantLocationMappingProfile()
        {
            //CreateMap<AddMerchantLocationCommand, Merchant>().ReverseMap();
            ////CreateMap<UpdateMerchantCommand, Merchant>().ReverseMap();
            ////CreateMap<DeleteMerchantCommand, Merchant>().ReverseMap();
            //CreateMap<MerchantLocation, MerchantLocationDto>();

            CreateMap<AddMerchantLocationCommand, MerchantLocation>()
               .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
               .ForMember(dest => dest.MerchantId, opt => opt.MapFrom(src => src.MerchantId))
               .ForMember(dest => dest.ParentID, opt => opt.MapFrom(src => src.ParentID))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.POCName, opt => opt.MapFrom(src => src.POCName))
               .ForMember(dest => dest.POCEmail, opt => opt.MapFrom(src => src.POCEmail))
               .ForMember(dest => dest.POCNumber, opt => opt.MapFrom(src => src.POCNumber))
               .ForMember(dest => dest.OtherEmail, opt => opt.MapFrom(src => src.OtherEmail))
               .ForMember(dest => dest.OtherNumber, opt => opt.MapFrom(src => src.OtherNumber)); // Ignore any extra properties in entity

            // Map MerchantLocation -> MerchantLocationDto
            CreateMap<MerchantLocation, MerchantLocationDto>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.MerchantId, opt => opt.MapFrom(src => src.MerchantId))
                .ForMember(dest => dest.ParentID, opt => opt.MapFrom(src => src.ParentID))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.POCName, opt => opt.MapFrom(src => src.POCName))
                .ForMember(dest => dest.POCEmail, opt => opt.MapFrom(src => src.POCEmail))
                .ForMember(dest => dest.POCNumber, opt => opt.MapFrom(src => src.POCNumber))
                .ForMember(dest => dest.OtherEmail, opt => opt.MapFrom(src => src.OtherEmail))
                .ForMember(dest => dest.OtherNumber, opt => opt.MapFrom(src => src.OtherNumber));



            CreateMap<UpdateMerchantLocationCommand, MerchantLocation>().ReverseMap();
            CreateMap<DeleteMerchantLocationCommand, MerchantLocation>().ReverseMap();
        }
    }
}
