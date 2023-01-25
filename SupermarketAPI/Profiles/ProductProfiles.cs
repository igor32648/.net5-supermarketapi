using AutoMapper;
using SupermarketAPI.Data.Dtos;
using SupermarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Profiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, ReadProductDto>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
