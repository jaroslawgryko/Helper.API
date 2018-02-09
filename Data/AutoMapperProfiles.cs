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
        }        
    }
}