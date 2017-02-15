using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace basicRPG.Models
{
    public class Foe
    {
        public int Id { get; set; }
        public bool IsAlien { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public byte[] Image { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual List<NPCInventory> NPCInventory { get; set; }
        public Foe()
        {

        }
        public Foe(bool isAlien, string name, int health, IFormFile image)
        {
            IsAlien = isAlien;
            Name = name;
            Health = health;
            byte[] imageArray = new byte[0];
            if (image.Length > 0)
            {
                using (var fileStream = image.OpenReadStream())
                using (var ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    imageArray = ms.ToArray();
                }
            }
            Image = imageArray;
        }
    }
}
