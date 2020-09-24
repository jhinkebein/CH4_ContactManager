using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManager.Migrations
{
    public partial class newRows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData( 
               table: "Categories",
               columns: new[] { "CategoryId", "Name" },
               values: new object[,]
               {
                    { 5, "Bob" } //He's so cool that he belongs in his own category
               });

            migrationBuilder.InsertData( 
               table: "Contacts",
               columns: new[] { "ContactId", "CategoryId", "DateAdded", "Email", "Firstname", "Lastname", "Organization", "Phone" },
               values: new object[] { 4, 5, new DateTime(2020, 9, 17, 19, 7, 3, 762, DateTimeKind.Local).AddTicks(2507), "bbilliamson@website.com", "Bob", "Billiamson", null, "555-555-4968" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData( //Have to cut bob the person off first or PMC gets angry
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "5");
        }
    }
}
