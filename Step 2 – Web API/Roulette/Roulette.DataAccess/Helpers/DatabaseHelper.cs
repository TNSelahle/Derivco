using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Roulette.DataAccess.Helpers
{
    public static class DatabaseHelper
    {
        public const string BetsCreateSql = "CREATE TABLE Bets (" +
            "UserId VARCHAR(50) NOT NULL," +
            "Type INTEGER NOT NULL," +
            "Value VARCHAR(20) NOT NULL)";

        public const string SpinsCreateSql = "CREATE TABLE Spins (" +
            "ID INTEGER PRIMARY KEY AUTOINCREMENT," +
            "Value INTEGER NOT NULL," +
            "DateCreated DATETIME DEFAULT (DATETIME('now','localtime')))";

        public static async void EnsureTableExists(this SqliteConnection connection, string table)
        {
            if (connection == null) return;

            var table_ = await connection.QueryAsync<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = @Table;", new { Table = table});
            var tableName = table_.FirstOrDefault();

            if (string.IsNullOrEmpty(tableName))
            {
                switch (table.ToLower())
                {
                    case "bets":
                        await connection.ExecuteAsync(BetsCreateSql);
                        break;
                    case "spins":
                        await connection.ExecuteAsync(SpinsCreateSql);
                            break;
                }
            }
        }
    }
}
