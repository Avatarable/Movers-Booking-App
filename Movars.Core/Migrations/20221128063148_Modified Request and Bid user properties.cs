using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movars.Core.Migrations
{
    public partial class ModifiedRequestandBiduserproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Mover_MoverId",
                schema: "Identity",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Mover_MoverId",
                schema: "Identity",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Owner_OwnerId",
                schema: "Identity",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "Mover",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Owner",
                schema: "Identity");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_User_MoverId",
                schema: "Identity",
                table: "Bids",
                column: "MoverId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_User_MoverId",
                schema: "Identity",
                table: "Requests",
                column: "MoverId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_User_OwnerId",
                schema: "Identity",
                table: "Requests",
                column: "OwnerId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_User_MoverId",
                schema: "Identity",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_User_MoverId",
                schema: "Identity",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_User_OwnerId",
                schema: "Identity",
                table: "Requests");

            migrationBuilder.CreateTable(
                name: "Mover",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    BusinessRegNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mover", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mover_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Identity",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owner_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Identity",
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mover_AddressId",
                schema: "Identity",
                table: "Mover",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_AddressId",
                schema: "Identity",
                table: "Owner",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Mover_MoverId",
                schema: "Identity",
                table: "Bids",
                column: "MoverId",
                principalSchema: "Identity",
                principalTable: "Mover",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Mover_MoverId",
                schema: "Identity",
                table: "Requests",
                column: "MoverId",
                principalSchema: "Identity",
                principalTable: "Mover",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Owner_OwnerId",
                schema: "Identity",
                table: "Requests",
                column: "OwnerId",
                principalSchema: "Identity",
                principalTable: "Owner",
                principalColumn: "Id");
        }
    }
}
