using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basicRPG.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Player> Players { get; set; }
        public virtual List<Foe> Foes { get; set; }
    }
}
