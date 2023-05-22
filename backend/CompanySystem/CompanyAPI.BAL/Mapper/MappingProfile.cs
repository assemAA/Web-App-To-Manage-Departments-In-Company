using AutoMapper;
using CompanyAPI.BAL.DTOs.Employee;
using CompanyAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.BAL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.departement, src => src.MapFrom(src => src.departement.name))
                .ReverseMap();

        
        }
    }
}
