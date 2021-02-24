using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataTransfer
{
    public class PlayerOverallStatDto
    {
        public UserDto Player { get; set; }
        public BaseballStatistic overallStats { get; set; }
    }
}
