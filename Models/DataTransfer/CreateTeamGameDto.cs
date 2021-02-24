using System;

namespace Models.DataTransfer
{
    public class CreateTeamGameDto
    {
        public Guid TeamID { get; set; }
        public Guid GameID { get; set; }
        public BaseballStatistic BaseballStatistic { get; set; }
    }
}
