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

            CreateMap<City, CityDto>()
               .ForMember(evw => evw.Name, opt => opt.MapFrom(em => em.CountryRef.Name))
               .ReverseMap()
               .ForPath(em => em.CountryRef.Name, opt => opt.Ignore());

            CreateMap<Location, LocationDto>().ReverseMap();

            CreateMap<HolidayPackage, HolidayPackageDto>()
               .ForMember(evw => evw.FromLocationRefId, opt => opt.MapFrom(em => em.FromLocationRef.LocationName))
               .ForMember(evw => evw.ToLocationRefId, opt => opt.MapFrom(em => em.ToLocationRef.LocationName))
               .ForMember(evw => evw.HotelRefId, opt => opt.MapFrom(em => em.HotelRef.Name))
               .ReverseMap()
               .ForPath(em => em.FromLocationRef.LocationName, opt => opt.Ignore())
               .ForPath(em => em.ToLocationRef.LocationName, opt => opt.Ignore())
               .ForPath(em => em.HotelRef.Name, opt => opt.Ignore());

            // CreateMap<Country, CountryDto>();

            //CreateMap<Country, CountryDto>()
            //    .ForMember(c => c.Name, opt => opt.MapFrom(c => c.Name))
            //    .ReverseMap()
            //    .ForPath(c => c.Name, opt => opt.Ignore());
        }
    }
}
