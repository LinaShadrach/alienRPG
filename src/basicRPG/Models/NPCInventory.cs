using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basicRPG.Models
{
    public class NPCInventory
    {
        public int Id { get; set; }
        public int FoeId { get; set; }
        public int ItemId { get; set; }
        public virtual Foe Foe { get; set; }
        public virtual Item Item { get; set; }
    }
}
