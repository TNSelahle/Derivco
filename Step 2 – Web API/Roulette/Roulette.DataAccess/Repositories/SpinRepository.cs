using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Roulette.Application.Interfaces.Repositories;
using Roulette.DataAccess.Helpers;
using Roulette.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.DataAccess.Repositories
{
    public class SpinRepository : ISpinRepository
    {
        private readonly IConfiguration _configuration;

        public SpinRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _configuration = configuration;
            using var connection = new SqliteConnection(_configuration.GetConnectionString("RouletteDb"));
            connection.EnsureTableExists("Spins");
        }
        public async Task AddAsync(Spin spin)
        {
            var sql = "INSERT INTO Spins (Value, DateCreated) VALUES (@Value, @DateCreated)";

            using var connection = new SqliteConnection(_configuration.GetConnectionString("RouletteDb"));

            await connection.ExecuteAsync(sql, spin);
        }

        public Task<IEnumerable<Spin>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
