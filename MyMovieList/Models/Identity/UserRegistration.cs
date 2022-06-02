using System.ComponentModel.DataAnnotations;

namespace MyMovieList.Models.Identity
{
    public class UserRegistration
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Username must be a valid email address.")]
        public string UserName { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;
    }
}
