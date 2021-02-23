using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataTransfer
{
    public class PlayerGameStatDto
    {
        public Guid playerId { get; set; }
        public Guid gameId { get; set; }
        public BaseballStatistic baseballStat { get; set; }
    }
}
