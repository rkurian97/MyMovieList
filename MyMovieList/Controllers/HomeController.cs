using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MyMovieList.Controllers
{
    public class HomeController : ApiController
    {
        [Authorize (AuthenticationSchemes = "Bearer")]
        public ActionResult Get()
        {
            return Ok("Works");
        }
    }
}