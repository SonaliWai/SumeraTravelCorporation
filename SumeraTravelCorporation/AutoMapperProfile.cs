using AutoMapper;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();

            // CreateMap<Country, CountryDto>();

            //CreateMap<Country, CountryDto>()
            //    .ForMember(c => c.Name, opt => opt.MapFrom(c => c.Name))
            //    .ReverseMap()
            //    .ForPath(c => c.Name, opt => opt.Ignore());
        }
    }
}
