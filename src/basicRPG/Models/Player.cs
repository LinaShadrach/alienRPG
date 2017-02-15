using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basicRPG.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int Health { get; set; }
        public int LocationId { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser AppUser { get; set; }
        public virtual Location Location { get; set; }
        public virtual List<PlayerInventory> PlayerInventory { get; set; }
    }
}
