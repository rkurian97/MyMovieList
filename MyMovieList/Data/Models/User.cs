using Microsoft.AspNetCore.Identity;

namespace MyMovieList.Data.Models
{
    public class User: IdentityUser
    {
        public List<Movie> ?Movies {get; set;}
    }
}
