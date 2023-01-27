using AutoMapper;
using SupermarketAPI.Data.Dtos.BrandDtos;
using SupermarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Profiles
{
    public class BrandProfiles : Profile
    {
        public BrandProfiles()
        {
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<Brand, ReadBrandDto>();
            CreateMap<UpdateBrandDto, Brand>();
        }
    }
}
