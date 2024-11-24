using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelRehAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

             migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Email = table.Column<string>(nullable: false),
                PasswordHash = table.Column<string>(nullable: false),
                PasswordSalt = table.Column<string>(nullable: true),
                FirstName = table.Column<string>(nullable: true),
                LastName = table.Column<string>(nullable: true),
                CreatedAt = table.Column<DateTime>(nullable: false),
                UpdatedAt = table.Column<DateTime>(nullable: false),
                IsActive = table.Column<bool>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
              // Users tablosunun silinmesi
              migrationBuilder.DropTable(
               name: "Users");

        }
    }
}
