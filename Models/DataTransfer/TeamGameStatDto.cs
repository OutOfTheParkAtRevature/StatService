using Model;
using System;

namespace Models.DataTransfer
{
    public class TeamGameStatDto
    {
        public Guid TeamID { get; set; }
        public Team Team { get; set; }
        public Guid GameID { get; set; }
        public Game Game { get; set; }
        public BaseballStatistic BaseballStat { get; set; }
    }
}
