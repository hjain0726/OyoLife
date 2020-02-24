using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OyoLife.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    No_Of_Bookings = table.Column<int>(nullable: false),
                    DealerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingAvailabilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dealer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Dealer_Name = table.Column<string>(nullable: true),
                    Dealer_Email = table.Column<string>(nullable: true),
                    Dealer_Password = table.Column<string>(nullable: true),
                    Dealer_PhoneNo = table.Column<string>(nullable: true),
                    Dealer_gender = table.Column<string>(nullable: true),
                    Dealer_age = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    PerDay_DealingCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealer", x => x.Id);
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
                name: "PG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pg_Name = table.Column<string>(nullable: true),
                    Pg_Price = table.Column<double>(nullable: false),
                    Pg_Type = table.Column<string>(nullable: true),
                    Pg_Sharing = table.Column<string>(nullable: true),
                    About_Pg = table.Column<string>(nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Booking_Date = table.Column<DateTime>(nullable: false),
                    Booking_Time = table.Column<string>(nullable: true),
                    PGId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DealerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Dealer_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    Line2 = table.Column<string>(nullable: true),
                    PGId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_PG_PGId",
                        column: x => x.PGId,
                        principalTable: "PG",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Facility_Name = table.Column<string>(nullable: true),
                    PGId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facilities_PG_PGId",
                        column: x => x.PGId,
                        principalTable: "PG",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PgImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_Url = table.Column<string>(nullable: true),
                    PGId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PgImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PgImages_PG_PGId",
                        column: x => x.PGId,
                        principalTable: "PG",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_PGId",
                table: "Address",
                column: "PGId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_DealerId",
                table: "Booking",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_PGId",
                table: "Facilities",
                column: "PGId");

            migrationBuilder.CreateIndex(
                name: "IX_PG_DealerId",
                table: "PG",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_PgImages_PGId",
                table: "PgImages",
                column: "PGId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "BookingAvailabilities");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "PgImages");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "PG");

            migrationBuilder.DropTable(
                name: "Dealer");
        }
    }
}
