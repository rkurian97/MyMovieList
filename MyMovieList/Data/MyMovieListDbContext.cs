using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMovieList.Data.Models;

namespace MyMovieList.Data
{
    public class MyMovieListDbContext : IdentityDbContext<User>
    {
        public MyMovieListDbContext(DbContextOptions<MyMovieListDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies {get; set;}
    }
}