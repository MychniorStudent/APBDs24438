using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RevenueRecognitionSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SubsProductsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_SoftwareSystems_SoftwareSystemId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_SoftwareSystemId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "SoftwareSystemId",
                table: "Subscriptions");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_IdSoftware",
                table: "Subscriptions",
                column: "IdSoftware");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_SoftwareSystems_IdSoftware",
                table: "Subscriptions",
                column: "IdSoftware",
                principalTable: "SoftwareSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_SoftwareSystems_IdSoftware",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_IdSoftware",
                table: "Subscriptions");

            migrationBuilder.AddColumn<Guid>(
                name: "SoftwareSystemId",
                table: "Subscriptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SoftwareSystemId",
                table: "Subscriptions",
                column: "SoftwareSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_SoftwareSystems_SoftwareSystemId",
                table: "Subscriptions",
                column: "SoftwareSystemId",
                principalTable: "SoftwareSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
