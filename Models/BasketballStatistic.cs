using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BasketballStatistic
    {
        [Key]
        [DisplayName("StatLine ID")]
        public Guid StatLineID { get; set; }
        public int Runs { get; set; }
        [DisplayName("Field Goals")]
        public int FGoals { get; set; }
        [DisplayName("Free Throws")]
        public int FThrows { get; set; }
        public int Rebounds { get; set; }
        public int Assissts { get; set; }
        public int Steals { get; set; }
        public int Turnovers { get; set; }
        public int Fouls { get; set; }
        [DisplayName("Possession Time")]
        public int PossessionTime { get; set; }

    }
}
