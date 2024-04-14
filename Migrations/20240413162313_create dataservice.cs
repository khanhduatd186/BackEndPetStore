using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPetShop.Migrations
{
    /// <inheritdoc />
    public partial class createdataservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Isdelete = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service_Cart",
                columns: table => new
                {
                    IdServie = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    dateTime = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Cart", x => new { x.IdUser, x.IdServie });
                    table.ForeignKey(
                        name: "FK_ServiceCart_Cart",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceCart_Product",
                        column: x => x.IdServie,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service_Detail",
                columns: table => new
                {
                    IdService = table.Column<int>(type: "int", nullable: false),
                    IdTime = table.Column<int>(type: "int", nullable: false),
                    SoLuongCa = table.Column<int>(type: "int", nullable: false),
                    NgayThucHien = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Detail", x => new { x.IdService, x.IdTime });
                    table.ForeignKey(
                        name: "FK_ServiceDetail_Service",
                        column: x => x.IdService,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDetail_Time",
                        column: x => x.IdTime,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_Cart_IdServie",
                table: "Service_Cart",
                column: "IdServie");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Detail_IdTime",
                table: "Service_Detail",
                column: "IdTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service_Cart");

            migrationBuilder.DropTable(
                name: "Service_Detail");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Time");
        }
    }
}
