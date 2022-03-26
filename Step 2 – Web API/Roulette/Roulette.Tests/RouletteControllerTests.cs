using NUnit;
using NUnit.Framework;
using Roulette.API.Controllers;
using Roulette.Domain.Models;
using Roulette.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Roulette.Tests
{
    public class RouletteControllerTests
    {
        [Test]
        public void PlaceBetShouldReturnSuccessStatusCodeIfParametersAreCorrect()
        {
            RouletteController roulette = new RouletteController();

            var bet = new Bet
            {
                UserId = "1001",
                Type = BetType.Number,
                Value = "4"
            };

            var response = roulette.PlaceBet(bet);

            Assert.IsNotNull(response);
            Assert.That(response, Is.TypeOf<OkResult>());
        }


    }
}
