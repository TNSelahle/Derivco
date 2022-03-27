using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Domain.Models
{
    public class Spin
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
