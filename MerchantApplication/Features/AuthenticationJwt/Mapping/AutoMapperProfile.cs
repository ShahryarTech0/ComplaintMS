using AutoMapper;
using MerchantApplication.Features.AuthenticationJwt.Dto;
using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.AuthenticationJwt.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User -> TokenResponseDto
            CreateMap<User, TokenResponseDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.AccessToken, opt => opt.Ignore())   // Set manually if needed
                .ForMember(dest => dest.RefreshToken, opt => opt.Ignore()); // Set manually if needed

            // Map UserDto to User
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // if you hash manually


            // ✅ Add this line:
            CreateMap<RefreshTokenResponseDto, User>().ReverseMap();
        }
    }
}
