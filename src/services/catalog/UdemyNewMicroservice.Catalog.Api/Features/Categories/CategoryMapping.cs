﻿using AutoMapper;
using UdemyNewMicroservice.Catalog.Api.Features.Categories.Dtos;

namespace UdemyNewMicroservice.Catalog.Api.Features.Categories
{
    public class CategoryMapping :Profile
    {
        public CategoryMapping()
        {
               CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
