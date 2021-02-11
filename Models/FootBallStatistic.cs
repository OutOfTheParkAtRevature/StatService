using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FootBallStatistic
    {
        [Key]
        [DisplayName("StatLine ID")]
        public Guid StatLineID { get; set; }
        [DisplayName("Yards Recieving")]
        public int YardsRec { get; set; }
        [DisplayName("Yards Running")]
        public int YardsRun { get; set; }
        public int Sacks { get; set; }
        public int Turnovers { get; set; }
        public int Plays { get; set; }
        [DisplayName("First Down Conversions")]
        public int FirstDownCons { get; set; }
        public int Penalties { get; set; }
        [DisplayName("Possession Time")]
        public int PossessionTime { get; set; }
        //public int SportId { get; set; }
    }
}
