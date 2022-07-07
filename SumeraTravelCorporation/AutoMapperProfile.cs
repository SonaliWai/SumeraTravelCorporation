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
            //CreateMap<Department, DepartmentDropDownViewModel>();

            //CreateMap<Employee, EmployeeViewModel>()
                //.ForMember(e => e.Name, opt => opt.MapFrom(e => e.CountryRef.Name))
                //.ReverseMap()
                //.ForPath(e => e.CountryRef.Name, opt => opt.Ignore());
        }
    }
}
