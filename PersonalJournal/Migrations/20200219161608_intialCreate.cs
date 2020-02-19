using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalJournal.Migrations
{
    public partial class intialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_AspNetUsers_ApplicationUserId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ApplicationUserId",
                table: "Entries");

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "EntryId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Entries");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Entries",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "19b89f63-2866-4ea0-b56c-e80f094f8ea7", "AQAAAAEAACcQAAAAEHFAOGaiCgUTSr6hz+JePJNqTcafr5W0bU9haPzeAZQcYHBkHcGJxr1EyMErxvjh0w==" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "EntryId", "Entries", "Mood", "UserId" },
                values: new object[] { 1, "Seeded data for journal application", "Determined", "00000000-ffff-ffff-ffff-ffffffffffff" });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_UserId",
                table: "Entries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_AspNetUsers_UserId",
                table: "Entries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_AspNetUsers_UserId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_UserId",
                table: "Entries");

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "EntryId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Entries");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Entries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb9884a9-7314-4fbc-8955-ccd1cf4107d6", "AQAAAAEAACcQAAAAEH1WB5jcEg+COFtuDMWY/G2/CxuckJHKICPkwF3ZNU3B2wVbZgAA2UiWm8wgCWu1qw==" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "EntryId", "ApplicationUserId", "Entries", "Mood" },
                values: new object[] { 1, null, "Seeded data for journal application", "Determined" });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ApplicationUserId",
                table: "Entries",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_AspNetUsers_ApplicationUserId",
                table: "Entries",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
