﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OyoLife.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Line1 = table.Column<string>(nullable: true),
                    Line2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Email = table.Column<string>(nullable: true),
                    User_Password = table.Column<string>(nullable: true),
                    user_name = table.Column<string>(nullable: true),
                    user_gender = table.Column<string>(nullable: true),
                    user_age = table.Column<int>(nullable: false),
                    user_phone = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dealer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dealer_Name = table.Column<string>(nullable: true),
                    Dealer_Email = table.Column<string>(nullable: true),
                    Dealer_PhoneNo = table.Column<string>(nullable: true),
                    Dealer_AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dealer_Address_Dealer_AddressId",
                        column: x => x.Dealer_AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pg_Name = table.Column<int>(nullable: false),
                    Pg_Price = table.Column<double>(nullable: false),
                    Pg_Type = table.Column<string>(nullable: true),
                    Pg_Sharing = table.Column<string>(nullable: true),
                    About_Pg = table.Column<string>(nullable: true),
                    Pg_AdressId = table.Column<int>(nullable: true),
                    Pg_Location = table.Column<string>(nullable: true),
                    DealerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PG_Dealer_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PG_Address_Pg_AdressId",
                        column: x => x.Pg_AdressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Booking_Date = table.Column<DateTime>(nullable: false),
                    PGID = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_PG_PGID",
                        column: x => x.PGID,
                        principalTable: "PG",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Facility_Name = table.Column<string>(nullable: true),
                    PGId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facility_PG_PGId",
                        column: x => x.PGId,
                        principalTable: "PG",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PgImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_Url = table.Column<string>(nullable: true),
                    PGId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PgImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PgImage_PG_PGId",
                        column: x => x.PGId,
                        principalTable: "PG",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PGID",
                table: "Booking",
                column: "PGID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dealer_Dealer_AddressId",
                table: "Dealer",
                column: "Dealer_AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_PGId",
                table: "Facility",
                column: "PGId");

            migrationBuilder.CreateIndex(
                name: "IX_PG_DealerId",
                table: "PG",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_PG_Pg_AdressId",
                table: "PG",
                column: "Pg_AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_PgImage_PGId",
                table: "PgImage",
                column: "PGId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "PgImage");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "PG");

            migrationBuilder.DropTable(
                name: "Dealer");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
