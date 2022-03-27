using Roulette.Application.Interfaces;
using Roulette.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBetRepository Bets { get; }

        public UnitOfWork(IBetRepository betRepository)
        {
            Bets = betRepository;
        }
    }
}
