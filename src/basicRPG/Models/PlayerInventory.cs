using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basicRPG.Models
{
    public class PlayerInventory
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        public virtual Item Item { get; set; }
    }
}
