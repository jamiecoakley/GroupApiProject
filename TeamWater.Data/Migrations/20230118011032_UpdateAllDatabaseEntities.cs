using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamWater.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAllDatabaseEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TvShows",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "PlatformId",
                table: "TvShows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ShowGenre",
                table: "TvShows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TvShowEntityId",
                table: "Episodes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TvShows_PlatformId",
                table: "TvShows",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShows_UserId",
                table: "TvShows",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowReviews_TvShowId",
                table: "ShowReviews",
                column: "TvShowId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ShowReviews_TvShows_TvShowId",
                table: "ShowReviews",
                column: "TvShowId",
                principalTable: "TvShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TvShows_StreamingPlatforms_PlatformId",
                table: "TvShows",
                column: "PlatformId",
                principalTable: "StreamingPlatforms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TvShows_Users_UserId",
                table: "TvShows",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_TvShows_TvShowEntityId",
                table: "Episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowReviews_TvShows_TvShowId",
                table: "ShowReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_TvShows_StreamingPlatforms_PlatformId",
                table: "TvShows");

            migrationBuilder.DropForeignKey(
                name: "FK_TvShows_Users_UserId",
                table: "TvShows");

            migrationBuilder.DropIndex(
                name: "IX_TvShows_PlatformId",
                table: "TvShows");

            migrationBuilder.DropIndex(
                name: "IX_TvShows_UserId",
                table: "TvShows");

            migrationBuilder.DropIndex(
                name: "IX_ShowReviews_TvShowId",
                table: "ShowReviews");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_TvShowEntityId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "ShowGenre",
                table: "TvShows");

            migrationBuilder.DropColumn(
                name: "TvShowEntityId",
                table: "Episodes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TvShows",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "PlatformId",
                table: "TvShows",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
