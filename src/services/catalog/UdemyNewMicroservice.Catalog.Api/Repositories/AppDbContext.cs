using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UdemyNewMicroservice.Catalog.Api.Features.Categories;
using UdemyNewMicroservice.Catalog.Api.Features.Courses;

namespace UdemyNewMicroservice.Catalog.Api.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }

        //Collection tablo ismi
        //Document satır ismi
        //field sutun ismi
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Bu assembly içerisindeki bütün configurationları al.UdemyNewMicroservice.Catalog.Api

        }
    }
}
