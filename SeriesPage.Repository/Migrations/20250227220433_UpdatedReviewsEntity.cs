using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeriesPage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedReviewsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserReviews",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "UserReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserReviews");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "UserReviews");
        }
    }
}
