using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinaCent.Blaze.Migrations
{
    public partial class UpdateAddFcmFcmUserTokenTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FCM.FcmDeviceTokenTopic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FCM.FcmDeviceTokenTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FCM.FcmDeviceTokenTopic_FCM.FcmTopic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "FCM.FcmTopic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FCM.FcmDeviceTokenTopic_TopicId",
                table: "FCM.FcmDeviceTokenTopic",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FCM.FcmDeviceTokenTopic");
        }
    }
}
