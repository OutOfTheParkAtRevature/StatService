using Model;
using System;

namespace Models.DataTransfer
{
    public class PlayerGameStatDto
    {
        public string playerId { get; set; }
        public UserDto Player { get; set; }
        public Guid gameId { get; set; }
        public Game Game { get; set; }
        public BaseballStatistic baseballStat { get; set; }
    }
}
