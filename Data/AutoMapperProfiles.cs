using System.Linq;
using AutoMapper;
using Helper.API.Dtos;
using Helper.API.Models;

namespace Helper.API.Data
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();

            CreateMap<Jednostka, JednostkaForDetailedDto>();
            CreateMap<User, UserForDetailedDto>();

            CreateMap<UserForUpdateDto, User>();


            CreateMap<JednostkaForRegisterDto, Jednostka>();
                
            CreateMap<Jednostka, JednostkaForListDto>()
                .ForMember(desc => desc.Parent, opt => {
                    opt.MapFrom(src => src.Parent);
                });

            CreateMap<Jednostka, JednostkaForTreeDto>()
                .ForMember(desc => desc.Parent, opt => {
                    opt.MapFrom(src => src.Parent);
                });            
        }        
    }
}