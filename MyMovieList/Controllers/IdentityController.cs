using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyMovieList.Data.Models;
using MyMovieList.Models.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyMovieList.Controllers
{
    public class IdentityController: ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly AppSettings appSettings;
        public IdentityController(UserManager<User> userManager, IOptions<AppSettings> appSettings)
        { 
            this.userManager = userManager;
            this.appSettings = appSettings.Value;
        }

        [Route(nameof(Register))]
        public async Task<ActionResult<object>> Register(UserRegistration model)
        {
            var user = new User
            {
                UserName = model.UserName
            };
            var result = await this.userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                return result;
            }
        
            return BadRequest(result.Errors);
        }

        [Route(nameof(Login))]
        public async Task<ActionResult<object>> Login(UserLogin model)
        {
            var user= await this.userManager.FindByNameAsync(model.UserName);
            if(user==null)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return new
            {
                Token= encryptedToken
            };
        }
    }
}
