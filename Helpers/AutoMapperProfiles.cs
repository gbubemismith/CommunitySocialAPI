using System.Linq;
using AutoMapper;
using CommunitySocial.API.Dtos;
using CommunitySocial.API.Models;

namespace CommunitySocial.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => 
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.age, opt => 
                    opt.MapFrom(src => src.DateOfBirth.CalculateAge()));

            CreateMap<User, UserForDetailsDto>()
                .ForMember(dest => dest.PhotoUrl, opt => 
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.age, opt => 
                    opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
                    
            CreateMap<Photo, PhotoForDetailsDto>();

            CreateMap<UserForUpdateDto, User>();

            CreateMap<Photo, PhotoForReturnDto>();

            CreateMap<PhotoForCreationDto, Photo>();

            CreateMap<UserForRegisterDto, User>();
        }
    }
}