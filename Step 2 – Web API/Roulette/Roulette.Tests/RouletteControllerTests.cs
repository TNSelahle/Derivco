using NUnit;
using NUnit.Framework;
using Roulette.API.Controllers;
using Roulette.Domain.Models;
using Roulette.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Roulette.DataAccess.Repositories;
using Roulette.Application.Interfaces;
using Roulette.Application.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Roulette.Tests
{
    public class RouletteControllerTests
    {
        private RouletteController _rouletteController;
        private IUnitOfWork _unitOfWork;
        private Mock<IBetRepository> _betRepoMock;

        [SetUp]
        public void Setup()
        {
            _betRepoMock = new Mock<IBetRepository>();
            _betRepoMock.Setup(x => x.AddAsync(It.IsAny<Bet>()));

            _unitOfWork = new UnitOfWork(_betRepoMock.Object);
            _rouletteController = new RouletteController(_unitOfWork);
        }

        #region PlaceBet

        [Test]
        public void PlaceBetShouldReturnSuccessStatusCodeIfParametersAreCorrect()
        {
            var bet = new Bet
            {
                UserId = "1001",
                Type = BetType.Number,
                Value = "4"
            };

            var response = _rouletteController.PlaceBet(bet);

            Assert.IsNotNull(response);
            Assert.That(response.Result as OkResult, Is.TypeOf<OkResult>());
        }

        // [Test]
        public void PlaceBetShouldReturnBadRequestIfPassedParametersAreNotCorrect()
        {
            var bet1 = new Bet
            {
                UserId = "10111",
                Type = BetType.Number
            };

            var bet2 = new Bet
            {
                Type = BetType.Color,
                Value = "Red"
            };

            var bet3 = new Bet
            {
                UserId = "Zorro",
                Value = "Yellow"
            };

            var response1 = _rouletteController.PlaceBet(bet1);
            var response2 = _rouletteController.PlaceBet(bet2);
            var response3 = _rouletteController.PlaceBet(bet3);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(response1);
                Assert.That(response2, Is.TypeOf<BadRequestResult>());
            });

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(response1);
                Assert.That(response2, Is.TypeOf<BadRequestResult>());
            });

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(response1);
                Assert.That(response2, Is.TypeOf<BadRequestResult>());
            });
        }

        [Test]
        public void PlaceBetShouldStoreBetInDatabase()
        {
            var bet = new Bet
            {
                UserId = "1001",
                Type = BetType.Number,
                Value = "4"
            };

            var response = _rouletteController.PlaceBet(bet);

            Assert.IsNotNull(response);
            Assert.That(response.Result as OkResult, Is.TypeOf<OkResult>());
            _betRepoMock.Verify(x => x.AddAsync(bet), Times.Once());
        }

        #endregion


    }
}
