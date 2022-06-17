using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovieList.Models.TMDBapi;

namespace MyMovieList.Controllers
{
    public class HomeController : ApiController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _logger=logger;
            _httpClientFactory = httpClientFactory;
            _config=config;
        }

        [Authorize (AuthenticationSchemes = "Bearer")]
        public ActionResult Get()
        {
            return Ok("Works");
        }
        
        [Route(nameof(GetPopularMovies))]
        [HttpGet]
        public async Task<ActionResult<RootObject>> GetPopularMovies(){
            string key=_config["TMDB:Key"];
            var HttpClient= _httpClientFactory.CreateClient("tmdb");
            var URL= $"movie/popular?api_key={key}";
            var response= await HttpClient.GetAsync(URL);
            return await response.Content.ReadFromJsonAsync<RootObject>();
        }
    }
}