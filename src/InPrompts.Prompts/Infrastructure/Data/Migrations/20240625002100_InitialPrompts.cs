using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    { 1, 2, "This is the body of the first prompt.", "First Prompt", "http://example.com/res1.jpg", "Text result for the first prompt.", "Prompt text for the first prompt.", "http://example.com/ref1.jpg", "Reference text for the first prompt.", 10, "www.supasebie.com", 100 },
                    { 2, 1, "This is the PostBodyText of the second prompt.", "Second Prompt", "http://example.com/res2.jpg", "Text result for the second prompt.", "Prompt text for the second prompt.", "http://example.com/ref2.jpg", "Reference text for the second prompt.", 20, "", 150 },
                    { 3, 3, "This is the PostBodyText of the third prompt.", "Third Prompt", "http://example.com/res3.jpg", "Text result for the third prompt.", "Prompt text for the third prompt.", "http://example.com/ref3.jpg", "Reference text for the third prompt.", 5, "", 50 },
                    { 4, 0, "This is the PostBodyText of the fourth prompt.", "Fourth Prompt", "http://example.com/res4.jpg", "Text result for the fourth prompt.", "Prompt text for the fourth prompt.", "http://example.com/ref4.jpg", "Reference text for the fourth prompt.", 7, "", 80 },
                    { 5, 4, "This is the PostBodyText of the fifth prompt.", "Fifth Prompt", "http://example.com/res5.jpg", "Text result for the fifth prompt.", "Prompt text for the fifth prompt.", "http://example.com/ref5.jpg", "Reference text for the fifth prompt.", 15, "", 120 },
                    { 6, 2, "This is the PostBodyText of the sixth prompt.", "Sixth Prompt", "http://example.com/res6.jpg", "Text result for the sixth prompt.", "Prompt text for the sixth prompt.", "http://example.com/ref6.jpg", "Reference text for the sixth prompt.", 8, "", 90 },
                    { 7, 1, "This is the PostBodyText of the seventh prompt.", "Seventh Prompt", "http://example.com/res7.jpg", "Text result for the seventh prompt.", "Prompt text for the seventh prompt.", "http://example.com/ref7.jpg", "Reference text for the seventh prompt.", 12, "", 110 },
                    { 8, 3, "This is the PostBodyText of the eighth prompt.", "Eighth Prompt", "http://example.com/res8.jpg", "Text result for the eighth prompt.", "Prompt text for the eighth prompt.", "http://example.com/ref8.jpg", "Reference text for the eighth prompt.", 14, "", 130 },
                    { 9, 0, "This is the PostBodyText of the ninth prompt.", "Ninth Prompt", "http://example.com/res9.jpg", "Text result for the ninth prompt.", "Prompt text for the ninth prompt.", "http://example.com/ref9.jpg", "Reference text for the ninth prompt.", 9, "", 75 },
                    { 10, 2, "This is the PostBodyText of the tenth prompt.", "Tenth Prompt", "http://example.com/res10.jpg", "Text result for the tenth prompt.", "Prompt text for the tenth prompt.", "http://example.com/ref10.jpg", "Reference text for the tenth prompt.", 18, "", 140 }
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
