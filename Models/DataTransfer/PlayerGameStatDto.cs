using System;

namespace Models.DataTransfer
{
    public class PlayerGameStatDto
    {
        public string playerId { get; set; }
        public Guid gameId { get; set; }
        public BaseballStatistic baseballStat { get; set; }
    }
}
