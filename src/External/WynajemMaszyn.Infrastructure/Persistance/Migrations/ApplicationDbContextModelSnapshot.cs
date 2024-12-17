﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WynajemMaszyn.Infrastructure;

#nullable disable

namespace WynajemMaszyn.Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.Excavator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DrivingSpeed")
                        .HasColumnType("integer");

                    b.Property<string>("Engine")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EnginePower")
                        .HasColumnType("integer");

                    b.Property<int>("FuelConsumption")
                        .HasColumnType("integer");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gearbox")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsRepair")
                        .HasColumnType("boolean");

                    b.Property<int>("MaxDiggingDepth")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OperatingHours")
                        .HasColumnType("integer");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("integer");

                    b.Property<float>("RentalPricePerDay")
                        .HasColumnType("real");

                    b.Property<string>("TypeChassis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TypeExcavator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Excavators");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.ExcavatorBucket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArmWidth")
                        .HasColumnType("integer");

                    b.Property<int>("BucketCapacity")
                        .HasColumnType("integer");

                    b.Property<string>("BucketType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CompatibleExcavators")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsRepair")
                        .HasColumnType("boolean");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MaxLoadCapacity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PinDiameter")
                        .HasColumnType("integer");

                    b.Property<int>("PinSpacing")
                        .HasColumnType("integer");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("integer");

                    b.Property<float>("RentalPricePerDay")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ExcavatorsBuckets");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.ExcavatorBucketList", b =>
                {
                    b.Property<int?>("ExcavatorBucketId")
                        .HasColumnType("integer");

                    b.Property<int?>("ExcavatorId")
                        .HasColumnType("integer");

                    b.HasIndex("ExcavatorBucketId");

                    b.HasIndex("ExcavatorId");

                    b.ToTable("ExcavatorBucketLists");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.Harvester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CuttingDiameter")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DrivingSpeed")
                        .HasColumnType("integer");

                    b.Property<string>("Engine")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EnginePower")
                        .HasColumnType("integer");

                    b.Property<int>("FuelConsumption")
                        .HasColumnType("integer");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsRepair")
                        .HasColumnType("boolean");

                    b.Property<int>("MaxReach")
                        .HasColumnType("integer");

                    b.Property<int>("MaxSpeed")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OperatingHours")
                        .HasColumnType("integer");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("integer");

                    b.Property<float>("RentalPricePerDay")
                        .HasColumnType("real");

                    b.Property<int>("TypeChassis")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Harvesters");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.Machinery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ExcavatorBucketId")
                        .HasColumnType("integer");

                    b.Property<int?>("ExcavatorId")
                        .HasColumnType("integer");

                    b.Property<int?>("HarvesterId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RollerId")
                        .HasColumnType("integer");

                    b.Property<int?>("WoodChipperId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExcavatorBucketId");

                    b.HasIndex("ExcavatorId");

                    b.HasIndex("HarvesterId");

                    b.HasIndex("RollerId");

                    b.HasIndex("WoodChipperId");

                    b.ToTable("Machiners");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.MachineryRental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalNotes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("BeginRent")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Contract")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<float?>("Deposit")
                        .HasColumnType("real");

                    b.Property<DateTime>("EndRent")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Facture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("boolean");

                    b.Property<float?>("LateFee")
                        .HasColumnType("real");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RentalStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MachineryRentals");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.MachineryRentalList", b =>
                {
                    b.Property<int>("MachineryId")
                        .HasColumnType("integer");

                    b.Property<int>("MachineryRentalId")
                        .HasColumnType("integer");

                    b.HasIndex("MachineryId");

                    b.HasIndex("MachineryRentalId");

                    b.ToTable("MachineryRentalLists");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.Roller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DrivingSpeed")
                        .HasColumnType("integer");

                    b.Property<int>("DrumWidth")
                        .HasColumnType("integer");

                    b.Property<string>("Engine")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EnginePower")
                        .HasColumnType("integer");

                    b.Property<int>("FuelConsumption")
                        .HasColumnType("integer");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gearbox")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsRepair")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsVibratory")
                        .HasColumnType("boolean");

                    b.Property<bool>("KnigeAsfalt")
                        .HasColumnType("boolean");

                    b.Property<int>("MaxCompactionForce")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberOfDrums")
                        .HasColumnType("integer");

                    b.Property<int>("OperatingHours")
                        .HasColumnType("integer");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("integer");

                    b.Property<float>("RentalPricePerDay")
                        .HasColumnType("real");

                    b.Property<string>("RollerType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Rollers");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PermissionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PermissionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.WoodChipper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChoppingHeight")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DrivingSpeed")
                        .HasColumnType("integer");

                    b.Property<string>("Engine")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EnginePower")
                        .HasColumnType("integer");

                    b.Property<int>("FlowMaterial")
                        .HasColumnType("integer");

                    b.Property<int>("FuelConsumption")
                        .HasColumnType("integer");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gearbox")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsRepair")
                        .HasColumnType("boolean");

                    b.Property<int>("MachineLength")
                        .HasColumnType("integer");

                    b.Property<int>("MachineWidth")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OperatingHours")
                        .HasColumnType("integer");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("integer");

                    b.Property<float>("RentalPricePerDay")
                        .HasColumnType("real");

                    b.Property<int>("TransportHeight")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WoodChippers");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.Excavator", b =>
                {
                    b.HasOne("WynajemMaszyn.Domain.Entities.User", "User")
                        .WithMany("Excavator")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.ExcavatorBucket", b =>
                {
                    b.HasOne("WynajemMaszyn.Domain.Entities.User", "User")
                        .WithMany("ExcavatorBucket")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.ExcavatorBucketList", b =>
                {
                    b.HasOne("WynajemMaszyn.Domain.Entities.ExcavatorBucket", "ExcavatorBucket")
                        .WithMany()
                        .HasForeignKey("ExcavatorBucketId");

                    b.HasOne("WynajemMaszyn.Domain.Entities.Excavator", "Excavator")
                        .WithMany()
                        .HasForeignKey("ExcavatorId");

                    b.Navigation("Excavator");

                    b.Navigation("ExcavatorBucket");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.Harvester", b =>
                {
                    b.HasOne("WynajemMaszyn.Domain.Entities.User", "User")
                        .WithMany("Harvester")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.Machinery", b =>
                {
                    b.HasOne("WynajemMaszyn.Domain.Entities.ExcavatorBucket", "ExcavatorBucket")
                        .WithMany()
                        .HasForeignKey("ExcavatorBucketId");

                    b.HasOne("WynajemMaszyn.Domain.Entities.Excavator", "Excavator")
                        .WithMany()
                        .HasForeignKey("ExcavatorId");

                    b.HasOne("WynajemMaszyn.Domain.Entities.Harvester", "Harvester")
                        .WithMany()
                        .HasForeignKey("HarvesterId");

                    b.HasOne("WynajemMaszyn.Domain.Entities.Roller", "Roller")
                        .WithMany()
                        .HasForeignKey("RollerId");

                    b.HasOne("WynajemMaszyn.Domain.Entities.WoodChipper", "WoodChipper")
                        .WithMany()
                        .HasForeignKey("WoodChipperId");

                    b.Navigation("Excavator");

                    b.Navigation("ExcavatorBucket");

                    b.Navigation("Harvester");

                    b.Navigation("Roller");

                    b.Navigation("WoodChipper");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.MachineryRental", b =>
                {
                    b.HasOne("WynajemMaszyn.Domain.Entities.User", "User")
                        .WithMany("MachineryRental")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.MachineryRentalList", b =>
                {
                    b.HasOne("WynajemMaszyn.Domain.Entities.Machinery", "Machinery")
                        .WithMany()
                        .HasForeignKey("MachineryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WynajemMaszyn.Domain.Entities.MachineryRental", "MachineryRental")
                        .WithMany()
                        .HasForeignKey("MachineryRentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machinery");

                    b.Navigation("MachineryRental");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.Roller", b =>
                {
                    b.HasOne("WynajemMaszyn.Domain.Entities.User", "User")
                        .WithMany("Roller")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.User", b =>
                {
                    b.HasOne("WynajemMaszyn.Domain.Entities.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.WoodChipper", b =>
                {
                    b.HasOne("WynajemMaszyn.Domain.Entities.User", "User")
                        .WithMany("WoodChipper")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WynajemMaszyn.Domain.Entities.User", b =>
                {
                    b.Navigation("Excavator");

                    b.Navigation("ExcavatorBucket");

                    b.Navigation("Harvester");

                    b.Navigation("MachineryRental");

                    b.Navigation("Roller");

                    b.Navigation("WoodChipper");
                });
#pragma warning restore 612, 618
        }
    }
}
