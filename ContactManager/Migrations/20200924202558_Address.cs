using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManager.Migrations
{
    public partial class Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>( //Address column in contacts
               name: "AddressId",
               table: "Contacts",
               nullable: false,
               defaultValue: 1); //Mary runs a cult so she'll appreciate this

            migrationBuilder.CreateTable( //new Address table
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.InsertData( //Populate addresses
                table: "Addresses",
                columns: new[] { "AddressId", "Address" },
                values: new object[,]
                {
                    { 1, "1 Walton Way" },
                    { 2, "2 Del Rio Drive" },
                    { 3, "3 Herrera Hallway" },
                    { 4, "Billiamson Court" } //They all live in the same city as the user of the list so he didnt feel like putting the city in
                });
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "AddressId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "AddressId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "AddressId",
                value: 3);
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 4,
                column: "AddressId",
                value: 4);

            migrationBuilder.AddForeignKey( //Create FK in contacts
                        name: "FK_Contacts_Addresses_AddressId",
                        table: "Contacts",
                        column: "AddressId",
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
        }
        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Addresses_AddressId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Contacts");
        }
    }
}
