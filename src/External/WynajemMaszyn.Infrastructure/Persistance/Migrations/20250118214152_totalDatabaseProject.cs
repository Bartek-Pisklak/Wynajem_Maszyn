﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WynajemMaszyn.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class totalDatabaseProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: true),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Excavators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TypeExcavator = table.Column<string>(type: "text", nullable: false),
                    TypeChassis = table.Column<string>(type: "text", nullable: false),
                    RentalPricePerDay = table.Column<float>(type: "real", nullable: false),
                    ProductionYear = table.Column<int>(type: "integer", nullable: false),
                    OperatingHours = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    Engine = table.Column<string>(type: "text", nullable: false),
                    EnginePower = table.Column<int>(type: "integer", nullable: false),
                    DrivingSpeed = table.Column<int>(type: "integer", nullable: false),
                    FuelConsumption = table.Column<int>(type: "integer", nullable: false),
                    FuelType = table.Column<string>(type: "text", nullable: false),
                    Gearbox = table.Column<string>(type: "text", nullable: false),
                    MaxDiggingDepth = table.Column<int>(type: "integer", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsRepair = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excavators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Excavators_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExcavatorsBuckets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BucketType = table.Column<string>(type: "text", nullable: false),
                    ProductionYear = table.Column<int>(type: "integer", nullable: false),
                    BucketCapacity = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    PinDiameter = table.Column<int>(type: "integer", nullable: false),
                    ArmWidth = table.Column<int>(type: "integer", nullable: false),
                    PinSpacing = table.Column<int>(type: "integer", nullable: false),
                    Material = table.Column<string>(type: "text", nullable: false),
                    MaxLoadCapacity = table.Column<int>(type: "integer", nullable: false),
                    RentalPricePerDay = table.Column<float>(type: "real", nullable: false),
                    CompatibleExcavators = table.Column<string>(type: "text", nullable: true),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsRepair = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcavatorsBuckets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExcavatorsBuckets_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Harvesters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProductionYear = table.Column<int>(type: "integer", nullable: false),
                    OperatingHours = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    Engine = table.Column<string>(type: "text", nullable: false),
                    EnginePower = table.Column<int>(type: "integer", nullable: false),
                    DrivingSpeed = table.Column<int>(type: "integer", nullable: false),
                    FuelType = table.Column<string>(type: "text", nullable: false),
                    FuelConsumption = table.Column<int>(type: "integer", nullable: false),
                    MaxSpeed = table.Column<int>(type: "integer", nullable: false),
                    CuttingDiameter = table.Column<int>(type: "integer", nullable: false),
                    MaxReach = table.Column<int>(type: "integer", nullable: false),
                    TypeChassis = table.Column<int>(type: "integer", nullable: false),
                    RentalPricePerDay = table.Column<float>(type: "real", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsRepair = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvesters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Harvesters_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineryRentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    BeginRent = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndRent = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RentalStatus = table.Column<string>(type: "text", nullable: false),
                    Deposit = table.Column<float>(type: "real", nullable: true),
                    LateFee = table.Column<float>(type: "real", nullable: true),
                    PaymentStatus = table.Column<string>(type: "text", nullable: false),
                    Facture = table.Column<string>(type: "text", nullable: true),
                    Contract = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    AdditionalNotes = table.Column<string>(type: "text", nullable: true),
                    IsReturned = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineryRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineryRentals_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rollers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProductionYear = table.Column<int>(type: "integer", nullable: false),
                    OperatingHours = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    RentalPricePerDay = table.Column<float>(type: "real", nullable: false),
                    Engine = table.Column<string>(type: "text", nullable: false),
                    EnginePower = table.Column<int>(type: "integer", nullable: false),
                    DrivingSpeed = table.Column<int>(type: "integer", nullable: false),
                    FuelConsumption = table.Column<int>(type: "integer", nullable: false),
                    FuelType = table.Column<string>(type: "text", nullable: false),
                    Gearbox = table.Column<string>(type: "text", nullable: false),
                    NumberOfDrums = table.Column<int>(type: "integer", nullable: false),
                    RollerType = table.Column<string>(type: "text", nullable: false),
                    DrumWidth = table.Column<int>(type: "integer", nullable: false),
                    MaxCompactionForce = table.Column<int>(type: "integer", nullable: false),
                    IsVibratory = table.Column<bool>(type: "boolean", nullable: false),
                    KnigeAsfalt = table.Column<bool>(type: "boolean", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsRepair = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rollers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rollers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WoodChippers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RentalPricePerDay = table.Column<float>(type: "real", nullable: false),
                    ProductionYear = table.Column<int>(type: "integer", nullable: false),
                    OperatingHours = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    FuelType = table.Column<string>(type: "text", nullable: false),
                    Engine = table.Column<string>(type: "text", nullable: false),
                    EnginePower = table.Column<int>(type: "integer", nullable: false),
                    Gearbox = table.Column<string>(type: "text", nullable: false),
                    DrivingSpeed = table.Column<int>(type: "integer", nullable: false),
                    FuelConsumption = table.Column<int>(type: "integer", nullable: false),
                    MachineLength = table.Column<int>(type: "integer", nullable: false),
                    TransportHeight = table.Column<int>(type: "integer", nullable: false),
                    ChoppingHeight = table.Column<int>(type: "integer", nullable: false),
                    MachineWidth = table.Column<int>(type: "integer", nullable: false),
                    FlowMaterial = table.Column<int>(type: "integer", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsRepair = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WoodChippers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WoodChippers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExcavatorBucketLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExcavatorId = table.Column<int>(type: "integer", nullable: true),
                    ExcavatorBucketId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcavatorBucketLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExcavatorBucketLists_ExcavatorsBuckets_ExcavatorBucketId",
                        column: x => x.ExcavatorBucketId,
                        principalTable: "ExcavatorsBuckets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExcavatorBucketLists_Excavators_ExcavatorId",
                        column: x => x.ExcavatorId,
                        principalTable: "Excavators",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Machiners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ExcavatorId = table.Column<int>(type: "integer", nullable: true),
                    ExcavatorBucketId = table.Column<int>(type: "integer", nullable: true),
                    RollerId = table.Column<int>(type: "integer", nullable: true),
                    HarvesterId = table.Column<int>(type: "integer", nullable: true),
                    WoodChipperId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machiners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machiners_ExcavatorsBuckets_ExcavatorBucketId",
                        column: x => x.ExcavatorBucketId,
                        principalTable: "ExcavatorsBuckets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Machiners_Excavators_ExcavatorId",
                        column: x => x.ExcavatorId,
                        principalTable: "Excavators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Machiners_Harvesters_HarvesterId",
                        column: x => x.HarvesterId,
                        principalTable: "Harvesters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Machiners_Rollers_RollerId",
                        column: x => x.RollerId,
                        principalTable: "Rollers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Machiners_WoodChippers_WoodChipperId",
                        column: x => x.WoodChipperId,
                        principalTable: "WoodChippers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MachineryRentalLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MachineryRentalId = table.Column<int>(type: "integer", nullable: false),
                    MachineryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineryRentalLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineryRentalLists_Machiners_MachineryId",
                        column: x => x.MachineryId,
                        principalTable: "Machiners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineryRentalLists_MachineryRentals_MachineryRentalId",
                        column: x => x.MachineryRentalId,
                        principalTable: "MachineryRentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExcavatorBucketLists_ExcavatorBucketId",
                table: "ExcavatorBucketLists",
                column: "ExcavatorBucketId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcavatorBucketLists_ExcavatorId",
                table: "ExcavatorBucketLists",
                column: "ExcavatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Excavators_UserId",
                table: "Excavators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcavatorsBuckets_UserId",
                table: "ExcavatorsBuckets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Harvesters_UserId",
                table: "Harvesters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Machiners_ExcavatorBucketId",
                table: "Machiners",
                column: "ExcavatorBucketId");

            migrationBuilder.CreateIndex(
                name: "IX_Machiners_ExcavatorId",
                table: "Machiners",
                column: "ExcavatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Machiners_HarvesterId",
                table: "Machiners",
                column: "HarvesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Machiners_RollerId",
                table: "Machiners",
                column: "RollerId");

            migrationBuilder.CreateIndex(
                name: "IX_Machiners_WoodChipperId",
                table: "Machiners",
                column: "WoodChipperId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineryRentalLists_MachineryId",
                table: "MachineryRentalLists",
                column: "MachineryId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineryRentalLists_MachineryRentalId",
                table: "MachineryRentalLists",
                column: "MachineryRentalId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineryRentals_UserId",
                table: "MachineryRentals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rollers_UserId",
                table: "Rollers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WoodChippers_UserId",
                table: "WoodChippers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcavatorBucketLists");

            migrationBuilder.DropTable(
                name: "MachineryRentalLists");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Machiners");

            migrationBuilder.DropTable(
                name: "MachineryRentals");

            migrationBuilder.DropTable(
                name: "ExcavatorsBuckets");

            migrationBuilder.DropTable(
                name: "Excavators");

            migrationBuilder.DropTable(
                name: "Harvesters");

            migrationBuilder.DropTable(
                name: "Rollers");

            migrationBuilder.DropTable(
                name: "WoodChippers");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
