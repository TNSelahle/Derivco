using Roulette.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Domain.Models
{
    public class Bet
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public BetType Type { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
