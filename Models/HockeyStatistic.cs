using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HockeyStatistic
    {
        [Key]
        [DisplayName("StatLine ID")]
        public Guid StatLineID { get; set; }
        public int Goals { get; set; }
        public int Shots { get; set; }
        public int Hits { get; set; }
        [DisplayName("Face Off Wins")]
        public int FaceOffWins { get; set; }
        [DisplayName("Power Play Opps")]
        public int PowerPlayOpps { get; set; }
        [DisplayName("Penalty Mins")]
        public int PenaltyMins { get; set; }
        public int Blocks { get; set; }
        [DisplayName("Take Aways")]
        public int TakeAWays { get; set; }
        [DisplayName("Give Aways")]
        public int GiveAways { get; set; }
    }
}
