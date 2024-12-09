using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JFS.Domain.Entities;
using JFS.Shared.DTOs;

namespace JFS.Application.Helper
{
    public class MapingProfile : Profile
    {
        public MapingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
