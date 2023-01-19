using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamWater.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedShowReviewEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateOfReview",
                table: "ShowReviews",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "ReviewTitle",
                table: "ShowReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewTitle",
                table: "ShowReviews");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfReview",
                table: "ShowReviews",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");
        }
    }
}
