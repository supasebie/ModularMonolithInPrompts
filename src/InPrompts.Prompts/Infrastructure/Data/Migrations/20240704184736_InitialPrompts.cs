using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InPrompts.Prompts.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialPrompts : Migration
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
                    UserEmail = table.Column<string>(type: "text", nullable: false),
                    PostTitle = table.Column<string>(type: "text", nullable: false),
                    PostBodyText = table.Column<string>(type: "text", nullable: false),
                    PromptText = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    ReferenceMaterialImageUrl = table.Column<string>(type: "text", nullable: false),
                    ReferenceMaterialText = table.Column<string>(type: "text", nullable: false),
                    PromptResultImageUrl = table.Column<string>(type: "text", nullable: false),
                    PromptResultText = table.Column<string>(type: "text", nullable: false),
                    UpVotes = table.Column<int>(type: "integer", nullable: false),
                    DownVotes = table.Column<int>(type: "integer", nullable: false),
                    ViewCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prompts", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Prompts",
                table: "Prompts",
                columns: new[] { "Id", "DownVotes", "PostBodyText", "PostTitle", "PromptResultImageUrl", "PromptResultText", "PromptText", "ReferenceMaterialImageUrl", "ReferenceMaterialText", "UpVotes", "UserEmail", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("a5f8e7d9-3a4b-4c7e-9d2f-4b5a1c3e6b8f"), 2, "This is the PostBodyText of the tenth prompt.", "Tenth Prompt", "http://example.com/res10.jpg", "Text result for the tenth prompt.", "Prompt text for the tenth prompt.", "http://example.com/ref10.jpg", "Reference text for the tenth prompt.", 18, "", 140 },
                    { new Guid("a9c3c99e-2ed6-4d9a-bc8d-6a3e9f78b8ac"), 0, "This is the PostBodyText of the fourth prompt.", "Fourth Prompt", "http://example.com/res4.jpg", "Text result for the fourth prompt.", "Prompt text for the fourth prompt.", "http://example.com/ref4.jpg", "Reference text for the fourth prompt.", 7, "", 80 },
                    { new Guid("b23b8e91-fef3-4094-ab3b-9e9d563d21b7"), 4, "This is the PostBodyText of the fifth prompt.", "Fifth Prompt", "http://example.com/res5.jpg", "Text result for the fifth prompt.", "Prompt text for the fifth prompt.", "http://example.com/ref5.jpg", "Reference text for the fifth prompt.", 15, "", 120 },
                    { new Guid("bbb5a494-3ced-4e39-9bc9-59e1ac8123a1"), 3, "This is the PostBodyText of the third prompt.", "Third Prompt", "http://example.com/res3.jpg", "Text result for the third prompt.", "Prompt text for the third prompt.", "http://example.com/ref3.jpg", "Reference text for the third prompt.", 5, "", 50 },
                    { new Guid("c4a1f4f8-e5f1-4b71-afac-d15b1b54b6c8"), 2, "This is the PostBodyText of the sixth prompt.", "Sixth Prompt", "http://example.com/res6.jpg", "Text result for the sixth prompt.", "Prompt text for the sixth prompt.", "http://example.com/ref6.jpg", "Reference text for the sixth prompt.", 8, "", 90 },
                    { new Guid("d6e9c4d8-f2ab-4aeb-a8fa-2d4ead4c5e99"), 1, "This is the PostBodyText of the seventh prompt.", "Seventh Prompt", "http://example.com/res7.jpg", "Text result for the seventh prompt.", "Prompt text for the seventh prompt.", "http://example.com/ref7.jpg", "Reference text for the seventh prompt.", 12, "", 110 },
                    { new Guid("dffe455b-8f20-4b08-9ec5-3b4a1ffc4d18"), 2, "This is the body of the first prompt.", "First Prompt", "http://example.com/res1.jpg", "Text result for the first prompt.", "Prompt text for the first prompt.", "http://example.com/ref1.jpg", "Reference text for the first prompt.", 10, "www.supasebie.com", 100 },
                    { new Guid("e7d1b8a1-1f23-4df3-ba84-5f9a1d1d4e34"), 3, "This is the PostBodyText of the eighth prompt.", "Eighth Prompt", "http://example.com/res8.jpg", "Text result for the eighth prompt.", "Prompt text for the eighth prompt.", "http://example.com/ref8.jpg", "Reference text for the eighth prompt.", 14, "", 130 },
                    { new Guid("f8e9b841-e4ad-45ed-a68c-04e5edd375fc"), 1, "This is the PostBodyText of the second prompt.", "Second Prompt", "http://example.com/res2.jpg", "Text result for the second prompt.", "Prompt text for the second prompt.", "http://example.com/ref2.jpg", "Reference text for the second prompt.", 20, "", 150 },
                    { new Guid("f9a2e4b7-2c5b-4fae-8d3b-6b2c1e4b8f4d"), 0, "This is the PostBodyText of the ninth prompt.", "Ninth Prompt", "http://example.com/res9.jpg", "Text result for the ninth prompt.", "Prompt text for the ninth prompt.", "http://example.com/ref9.jpg", "Reference text for the ninth prompt.", 9, "", 75 }
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
