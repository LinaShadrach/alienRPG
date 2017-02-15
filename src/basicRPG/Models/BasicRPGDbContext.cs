using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basicRPG.Models
{
    public class BasicRPGDbContext : IdentityDbContext<ApplicationUser>
    {
        public BasicRPGDbContext()
        {

        }
        public BasicRPGDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Foe> Foes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<NPCInventory> NPCInventory { get; set; }
        public DbSet<PlayerInventory> PlayerInventory { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BasicRPG;integrated security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Foe>()
                .HasKey(f => f.Id);
            modelBuilder.Entity<Item>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Location>()
                .HasKey(l => l.Id);
            modelBuilder.Entity<NPCInventory>()
                .HasKey(n => n.Id);
            modelBuilder.Entity<NPCInventory>()
                .HasOne(n => n.Foe)
                .WithMany(f => f.NPCInventory)
                .HasForeignKey(n => n.FoeId);
            modelBuilder.Entity<NPCInventory>()
                .HasOne(n => n.Item)
                .WithMany(i => i.NPCInventory)
                .HasForeignKey(n => n.ItemId);
            modelBuilder.Entity<PlayerInventory>()
                .HasKey(n => n.Id);
            modelBuilder.Entity<PlayerInventory>()
                .HasOne(n => n.Player)
                .WithMany(f => f.PlayerInventory)
                .HasForeignKey(n => n.PlayerId);
            modelBuilder.Entity<PlayerInventory>()
                .HasOne(n => n.Item)
                .WithMany(i => i.PlayerInventory)
                .HasForeignKey(n => n.ItemId);

                base.OnModelCreating(modelBuilder);
        }
    }
}
