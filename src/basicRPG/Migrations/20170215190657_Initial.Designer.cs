using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using basicRPG.Models;

namespace basicRPG.Migrations
{
    [DbContext(typeof(BasicRPGDbContext))]
    [Migration("20170215190657_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("basicRPG.Models.Foe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Health");

                    b.Property<byte[]>("Image");

                    b.Property<bool>("IsAlien");

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Foes");
                });

            modelBuilder.Entity("basicRPG.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Effect");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("basicRPG.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("basicRPG.Models.NPCInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FoeId");

                    b.Property<int>("ItemId");

                    b.HasKey("Id");

                    b.HasIndex("FoeId");

                    b.HasIndex("ItemId");

                    b.ToTable("NPCInventory");
                });

            modelBuilder.Entity("basicRPG.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Health");

                    b.Property<byte[]>("Image");

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("basicRPG.Models.PlayerInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ItemId");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerInventory");
                });

            modelBuilder.Entity("basicRPG.Models.Foe", b =>
                {
                    b.HasOne("basicRPG.Models.Location", "Location")
                        .WithMany("Foes")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("basicRPG.Models.NPCInventory", b =>
                {
                    b.HasOne("basicRPG.Models.Foe", "Foe")
                        .WithMany("NPCInventory")
                        .HasForeignKey("FoeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("basicRPG.Models.Item", "Item")
                        .WithMany("NPCInventory")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("basicRPG.Models.Player", b =>
                {
                    b.HasOne("basicRPG.Models.Location", "Location")
                        .WithMany("Players")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("basicRPG.Models.PlayerInventory", b =>
                {
                    b.HasOne("basicRPG.Models.Item", "Item")
                        .WithMany("PlayerInventory")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("basicRPG.Models.Player", "Player")
                        .WithMany("PlayerInventory")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
