﻿using UdemyNewMicroservice.Catalog.Api.Features.Courses;
using UdemyNewMicroservice.Catalog.Api.Repositories;

namespace UdemyNewMicroservice.Catalog.Api.Features.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!; //default! bu property'nin null olamayacağını belirtir.
        public List<Course>? Courses { get; set; }
    }
}