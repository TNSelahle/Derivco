using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Roulette.Application.Interfaces;
using Roulette.Application.Interfaces.Repositories;
using Roulette.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.DataAccess.Helpers;

namespace Roulette.DataAccess.Repositories
{
    public class BetRepository : IBetRepository
    {
        private readonly IConfiguration _configuration;

        public BetRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            using var connection = new SqliteConnection(_configuration.GetConnectionString("RouletteDb"));
            connection.EnsureTableExists("Bets");
        }

        public async Task AddAsync(Bet bet)
        {
            var sql = "INSERT INTO Bets (UserId, Type, Value) VALUES (@UserId, @Type, @Value)";

            using var connection = new SqliteConnection(_configuration.GetConnectionString("RouletteDb"));

            await connection.ExecuteAsync(sql, bet);
        }

        public Task<IEnumerable<Bet>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
