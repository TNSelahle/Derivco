using Roulette.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IBetRepository Bets { get; }
        ISpinRepository Spins { get; }
    }
}
