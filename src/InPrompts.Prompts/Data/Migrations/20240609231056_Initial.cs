using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InPrompts.Prompts.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Prompts");

            migrationBuilder.CreateTable(
                name: "Prompts",
                schema: "Prompts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    User = table.Column<string>(type: "text", nullable: false),
                    ViewCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prompts", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Prompts",
                table: "Prompts",
                columns: new[] { "Id", "Text", "User", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("bbb5a494-3ced-4e39-9bc9-59e1ac8123a1"), "What is your favorite movie?", "Soren", 2 },
                    { new Guid("dffe455b-8f20-4b08-9ec5-3b4a1ffc4d18"), "What is your favorite color?", "Daniel", 13 },
                    { new Guid("f8e9b841-e4ad-45ed-a68c-04e5edd375fc"), "What is your favorite food?", "Dom", 13 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prompts",
                schema: "Prompts");
        }
    }
}
