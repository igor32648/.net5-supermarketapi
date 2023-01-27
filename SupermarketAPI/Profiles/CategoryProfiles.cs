using AutoMapper;
using SupermarketAPI.Data.Dtos;
using SupermarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Profiles
{
    public class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, ReadCategoryDto>();
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}
