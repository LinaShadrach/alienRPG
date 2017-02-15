using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basicRPG.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Effect { get; set; }
        public virtual List<NPCInventory> NPCInventory { get; set; }
        public virtual List<PlayerInventory> PlayerInventory { get; set; }
    }
}
