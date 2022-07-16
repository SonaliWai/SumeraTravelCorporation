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
               .ForMember(evw => evw.CountryRefName, opt => opt.MapFrom(em => em.CountryRef.Name))
               .ReverseMap()
               .ForPath(em => em.CountryRef.Name, opt => opt.Ignore());

            CreateMap<Location, LocationDto>().ReverseMap();

            CreateMap<HolidayPackage, HolidayPackageDto>()
               .ForMember(evw => evw.FromLocationRefName, opt => opt.MapFrom(em => em.FromLocationRef.LocationName))
               .ForMember(evw => evw.ToLocationRefName, opt => opt.MapFrom(em => em.ToLocationRef.LocationName))
               .ForMember(evw => evw.HotelRefName, opt => opt.MapFrom(em => em.HotelRef.Name))
               .ReverseMap()
               .ForPath(em => em.FromLocationRef.LocationName, opt => opt.Ignore())
               .ForPath(em => em.ToLocationRef.LocationName, opt => opt.Ignore())
               .ForPath(em => em.HotelRef.Name, opt => opt.Ignore());

            CreateMap<HolidayBooking, HolidayBookingDto>()
              //.ForMember(evw => evw.HolidayPackageRefId, opt => opt.MapFrom(em => em.HolidayPackageRef.Id))
              .ForMember(evw => evw.CustomerRefName, opt => opt.MapFrom(em => em.CustomerRef.FirstName))
              .ReverseMap()
             // .ForPath(em => em.HolidayPackageRef.Id, opt => opt.Ignore())
              .ForPath(em => em.CustomerRef.FirstName, opt => opt.Ignore());

            // CreateMap<Country, CountryDto>();

            //CreateMap<Country, CountryDto>()
            //    .ForMember(c => c.Name, opt => opt.MapFrom(c => c.Name))
            //    .ReverseMap()
            //    .ForPath(c => c.Name, opt => opt.Ignore());
        }
    }
}
