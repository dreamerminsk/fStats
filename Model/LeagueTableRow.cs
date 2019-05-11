using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fStats.Model
{
    public class LeagueTableRow
    {
        public int Position { get; set; }
        public string Team { get; set; }
        public int Games { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GF { get; set; }
        public int GA { get; set; }
        public int GD { get; set; }
        public int Points { get; set; }

        public LeagueTableRow()
        {

        }
    }
}
