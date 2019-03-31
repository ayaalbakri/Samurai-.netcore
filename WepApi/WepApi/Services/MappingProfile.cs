using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Models;

namespace WepApi.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<PointOfInterest, PointOfInterestDto>().ReverseMap();
        }

    }
}
