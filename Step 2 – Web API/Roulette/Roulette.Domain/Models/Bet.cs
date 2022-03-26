using Roulette.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Domain.Models
{
    public class Bet
    {
        public string UserId { get; set; }
        public BetType Type { get; set; }
        public string Value { get; set; }
    }
}
