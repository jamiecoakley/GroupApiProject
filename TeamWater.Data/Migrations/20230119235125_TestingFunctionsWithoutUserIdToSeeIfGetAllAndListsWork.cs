using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamWater.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestingFunctionsWithoutUserIdToSeeIfGetAllAndListsWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TvShows_Users_UserId",
                table: "TvShows");

            migrationBuilder.DropIndex(
                name: "IX_TvShows_UserId",
                table: "TvShows");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TvShows");

            migrationBuilder.AddColumn<int>(
                name: "EpisodeEntityId",
                table: "EpisodeReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "EpisodeReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeReviews_EpisodeEntityId",
                table: "EpisodeReviews",
                column: "EpisodeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeReviews_UserEntityId",
                table: "EpisodeReviews",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeReviews_Episodes_EpisodeEntityId",
                table: "EpisodeReviews",
                column: "EpisodeEntityId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeReviews_Users_UserEntityId",
                table: "EpisodeReviews",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeReviews_Episodes_EpisodeEntityId",
                table: "EpisodeReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeReviews_Users_UserEntityId",
                table: "EpisodeReviews");

            migrationBuilder.DropIndex(
                name: "IX_EpisodeReviews_EpisodeEntityId",
                table: "EpisodeReviews");

            migrationBuilder.DropIndex(
                name: "IX_EpisodeReviews_UserEntityId",
                table: "EpisodeReviews");

            migrationBuilder.DropColumn(
                name: "EpisodeEntityId",
                table: "EpisodeReviews");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "EpisodeReviews");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TvShows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TvShows_UserId",
                table: "TvShows",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TvShows_Users_UserId",
                table: "TvShows",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
