using Microsoft.AspNetCore.Mvc;

namespace MyMovieList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
