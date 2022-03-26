using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roulette.Domain.Models;
using System.Threading.Tasks;

namespace Roulette.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        [HttpGet]
        [ApiVersion("1.0")]
        [Route("api/v{version:apiVersion}/PlaceBet")]
        public IActionResult PlaceBet(Bet bet)
        {
            return new OkResult();
        }
    }

}
