using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyMovieList.Data.Models;

public class Movie{
    [Key]
    [Required]
    public int Id {get; set;}

    [Required]
    public int movieId {get;set;}

    [Required]
    public int rating {get;set;}

    
    [Required]
    [ForeignKey("User")]
    public string userId {get;set;}= default!;
    public User User {get;set;}= new User();

}