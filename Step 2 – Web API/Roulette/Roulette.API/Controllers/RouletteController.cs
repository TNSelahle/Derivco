using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roulette.Application.Interfaces;
using Roulette.Domain.Models;
using System.Threading.Tasks;

namespace Roulette.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RouletteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        [Route("api/v{version:apiVersion}/PlaceBet")]
        public async Task<IActionResult> PlaceBet(Bet bet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _unitOfWork.Bets.AddAsync(bet);

            return new OkResult();
        }
    }

}
