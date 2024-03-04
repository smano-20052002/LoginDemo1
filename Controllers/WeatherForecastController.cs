using Microsoft.AspNetCore.Mvc;
using LoginDemo1.OtherOperation;
using LoginDemo1.DataContext;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using LoginDemo1.Model;
using System.Security.Claims;

namespace LoginDemo1.Controllers

{
    [ApiController]
    [Route("/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

       // private readonly ILogger<WeatherForecastController> _logger;
        //private readonly IConfiguration _configuration;

        public WeatherForecastController()
        {
           
            //_configuration = configuration;
        }
        [HttpGet]

        //[CustomRoleAuthorizeAttributes("430a9459-e1e5-47b8-9a91-e299df67bd41")]
        
        [CustomRoleAuthorize("430a9459-e1e5-47b8-9a91-e299df67bd41")]
        [Route("/api/WeatherForecast")]
        public IActionResult Get()
        {

            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            return Ok(token);
            


            
        }
    }
}
