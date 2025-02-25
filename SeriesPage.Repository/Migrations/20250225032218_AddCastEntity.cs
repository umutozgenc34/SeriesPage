using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeriesPage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddCastEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameInTheSeries = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RealName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cast", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cast");
        }
    }
}
