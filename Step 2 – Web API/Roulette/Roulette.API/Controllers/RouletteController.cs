using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roulette.Application.Interfaces;
using Roulette.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Roulette.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Random rnd = new Random();

        public RouletteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("PlaceBet")]
        public async Task<IActionResult> PlaceBet(Bet bet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _unitOfWork.Bets.AddAsync(bet);

            return new OkResult();
        }

        [HttpGet]
        [Route("Spin")]
        public async Task<int> Spin()
        {
            var spin = rnd.Next(37);

            await _unitOfWork.Spins.AddAsync(new Spin { Value = spin });

            return spin;
        }
    }

}
