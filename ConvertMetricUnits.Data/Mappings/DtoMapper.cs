using AutoMapper;
using ConvertMetricUnits.Data.Models;
using ConvertMetricUnits.Data.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertMetricUnits.Data.Mappings
{
    public class DtoMapper:Profile
    {
        public DtoMapper()
        {
            CreateMap<Formula, FormulaDto>().ReverseMap();
            CreateMap<Length, LengthDto>().ReverseMap();
            CreateMap<Temparature, TemparatureDto>().ReverseMap();
            CreateMap<Weight, WeightDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
