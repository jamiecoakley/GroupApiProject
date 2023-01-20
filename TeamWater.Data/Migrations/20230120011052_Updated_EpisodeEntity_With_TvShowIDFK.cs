using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamWater.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEpisodeEntityWithTvShowIDFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_TvShows_TvShowEntityId",
                table: "Episodes");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_TvShowEntityId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "TvShowEntityId",
                table: "Episodes");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Episodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_TvShowId",
                table: "Episodes",
                column: "TvShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_TvShows_TvShowId",
                table: "Episodes",
                column: "TvShowId",
                principalTable: "TvShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_TvShows_TvShowId",
                table: "Episodes");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_TvShowId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Episodes");

            migrationBuilder.AddColumn<int>(
                name: "TvShowEntityId",
                table: "Episodes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_TvShowEntityId",
                table: "Episodes",
                column: "TvShowEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_TvShows_TvShowEntityId",
                table: "Episodes",
                column: "TvShowEntityId",
                principalTable: "TvShows",
                principalColumn: "Id");
        }
    }
}
