using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BatteryCondition.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BatteryBrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BatteryBrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BatteryBrandId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "BatteryModels",
                columns: table => new
                {
                    BatteryModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BatteryBrandId = table.Column<int>(nullable: false),
                    BatteryCapacity = table.Column<int>(nullable: false),
                    BatteryModelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryModels", x => x.BatteryModelId);
                    table.ForeignKey(
                        name: "FK_BatteryModels_Brands_BatteryBrandId",
                        column: x => x.BatteryBrandId,
                        principalTable: "Brands",
                        principalColumn: "BatteryBrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    StreetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityId = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.StreetId);
                    table.ForeignKey(
                        name: "FK_Streets_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BatteryConditions",
                columns: table => new
                {
                    BatteryConditionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BatteryModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryConditions", x => x.BatteryConditionId);
                    table.ForeignKey(
                        name: "FK_BatteryConditions_BatteryModels_BatteryModelId",
                        column: x => x.BatteryModelId,
                        principalTable: "BatteryModels",
                        principalColumn: "BatteryModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    HouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HouseNumber = table.Column<string>(nullable: true),
                    StreetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.HouseId);
                    table.ForeignKey(
                        name: "FK_Houses_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "StreetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CapacityByDates",
                columns: table => new
                {
                    CapacityByDateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BatteryConditionId = table.Column<int>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityByDates", x => x.CapacityByDateId);
                    table.ForeignKey(
                        name: "FK_CapacityByDates_BatteryConditions_BatteryConditionId",
                        column: x => x.BatteryConditionId,
                        principalTable: "BatteryConditions",
                        principalColumn: "BatteryConditionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddressByDates",
                columns: table => new
                {
                    AddressByDateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BatteryConditionId = table.Column<int>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    HouseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressByDates", x => x.AddressByDateId);
                    table.ForeignKey(
                        name: "FK_AddressByDates_BatteryConditions_BatteryConditionId",
                        column: x => x.BatteryConditionId,
                        principalTable: "BatteryConditions",
                        principalColumn: "BatteryConditionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddressByDates_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressByDates_BatteryConditionId",
                table: "AddressByDates",
                column: "BatteryConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressByDates_HouseId",
                table: "AddressByDates",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryConditions_BatteryModelId",
                table: "BatteryConditions",
                column: "BatteryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryModels_BatteryBrandId",
                table: "BatteryModels",
                column: "BatteryBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CapacityByDates_BatteryConditionId",
                table: "CapacityByDates",
                column: "BatteryConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_StreetId",
                table: "Houses",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_CityId",
                table: "Streets",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressByDates");

            migrationBuilder.DropTable(
                name: "CapacityByDates");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "BatteryConditions");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "BatteryModels");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
