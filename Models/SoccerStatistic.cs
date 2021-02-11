using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SoccerStatistic
    {
        [Key]
        [DisplayName("StatLine ID")]
        public Guid StatLineID { get; set; }
        public int Goals { get; set; }
        [DisplayName("Shots On Goal")]
        public int ShotOnGoal { get; set; }
        public int Fouls { get; set; }
        [DisplayName("Yellow Cards")]
        public int yellowCards { get; set; }
        [DisplayName("Red Cards")]
        public int RedCards { get; set; }
        [DisplayName("Off Sides")]
        public int OffSides { get; set; }
        [DisplayName("Corner Kicks")]
        public int CornerKicks { get; set; }
        [DisplayName("Possession Time")]
        public int PossessionTime { get; set; }
        //public int SportId { get; set; }
    }
}
