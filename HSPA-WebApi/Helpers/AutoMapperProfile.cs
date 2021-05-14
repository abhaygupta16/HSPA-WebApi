using AutoMapper;
using HSPA_WebApi.Dtos;
using HSPA_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSPA_WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<CityDto, City>();
        }
    }
}
