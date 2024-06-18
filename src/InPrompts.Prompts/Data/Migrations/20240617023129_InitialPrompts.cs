using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InPrompts.Prompts.Data.Migrations
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
                    Title = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    ReferenceImageUrl = table.Column<string>(type: "text", nullable: false),
                    ImageResultUrl = table.Column<string>(type: "text", nullable: false),
                    ReferenceText = table.Column<string>(type: "text", nullable: false),
                    TextResult = table.Column<string>(type: "text", nullable: false),
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
                columns: new[] { "Id", "Body", "DownVotes", "ImageResultUrl", "ReferenceImageUrl", "ReferenceText", "Text", "TextResult", "Title", "UpVotes", "UserEmail", "ViewCount" },
                values: new object[,]
                {
                    { 1, "This is the body of the first prompt.", 2, "http://example.com/res1.jpg", "http://example.com/ref1.jpg", "Reference text for the first prompt.", "Prompt text for the first prompt.", "Text result for the first prompt.", "First Prompt", 10, "www.supasebie.com", 100 },
                    { 2, "This is the body of the second prompt.", 1, "http://example.com/res2.jpg", "http://example.com/ref2.jpg", "Reference text for the second prompt.", "Prompt text for the second prompt.", "Text result for the second prompt.", "Second Prompt", 20, "", 150 },
                    { 3, "This is the body of the third prompt.", 3, "http://example.com/res3.jpg", "http://example.com/ref3.jpg", "Reference text for the third prompt.", "Prompt text for the third prompt.", "Text result for the third prompt.", "Third Prompt", 5, "", 50 },
                    { 4, "This is the body of the fourth prompt.", 0, "http://example.com/res4.jpg", "http://example.com/ref4.jpg", "Reference text for the fourth prompt.", "Prompt text for the fourth prompt.", "Text result for the fourth prompt.", "Fourth Prompt", 7, "", 80 },
                    { 5, "This is the body of the fifth prompt.", 4, "http://example.com/res5.jpg", "http://example.com/ref5.jpg", "Reference text for the fifth prompt.", "Prompt text for the fifth prompt.", "Text result for the fifth prompt.", "Fifth Prompt", 15, "", 120 },
                    { 6, "This is the body of the sixth prompt.", 2, "http://example.com/res6.jpg", "http://example.com/ref6.jpg", "Reference text for the sixth prompt.", "Prompt text for the sixth prompt.", "Text result for the sixth prompt.", "Sixth Prompt", 8, "", 90 },
                    { 7, "This is the body of the seventh prompt.", 1, "http://example.com/res7.jpg", "http://example.com/ref7.jpg", "Reference text for the seventh prompt.", "Prompt text for the seventh prompt.", "Text result for the seventh prompt.", "Seventh Prompt", 12, "", 110 },
                    { 8, "This is the body of the eighth prompt.", 3, "http://example.com/res8.jpg", "http://example.com/ref8.jpg", "Reference text for the eighth prompt.", "Prompt text for the eighth prompt.", "Text result for the eighth prompt.", "Eighth Prompt", 14, "", 130 },
                    { 9, "This is the body of the ninth prompt.", 0, "http://example.com/res9.jpg", "http://example.com/ref9.jpg", "Reference text for the ninth prompt.", "Prompt text for the ninth prompt.", "Text result for the ninth prompt.", "Ninth Prompt", 9, "", 75 },
                    { 10, "This is the body of the tenth prompt.", 2, "http://example.com/res10.jpg", "http://example.com/ref10.jpg", "Reference text for the tenth prompt.", "Prompt text for the tenth prompt.", "Text result for the tenth prompt.", "Tenth Prompt", 18, "", 140 }
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
