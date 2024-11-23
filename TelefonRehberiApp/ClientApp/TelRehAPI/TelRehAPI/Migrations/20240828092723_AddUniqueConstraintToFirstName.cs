using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelRehAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintToFirstName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
            name: "IX_Contacts_FirstName",
            table: "Contacts",
            columns: new[] { "FirstName", "LastName" }, 
            unique: true);  // İsim ve soyisim çiftlerinin benzersiz olmasını sağla
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
            name: "IX_Contacts_FirstName",
            table: "Contacts");

    }
    }
}
