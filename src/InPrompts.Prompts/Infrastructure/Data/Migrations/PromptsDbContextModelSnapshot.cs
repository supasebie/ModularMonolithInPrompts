﻿// <auto-generated />
using System;
using InPrompts.Prompts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InPrompts.Prompts.Infrastructure.Data.Migrations
{
    [DbContext(typeof(PromptsDbContext))]
    partial class PromptsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Prompts")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InPrompts.Prompts.Prompt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("DownVotes")
                        .HasColumnType("integer");

                    b.Property<string>("PostBodyText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PromptResultImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PromptResultText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PromptText")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<string>("ReferenceMaterialImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReferenceMaterialText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UpVotes")
                        .HasColumnType("integer");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ViewCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Prompts", "Prompts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dffe455b-8f20-4b08-9ec5-3b4a1ffc4d18"),
                            DownVotes = 2,
                            PostBodyText = "This is the body of the first prompt.",
                            PostTitle = "First Prompt",
                            PromptResultImageUrl = "http://example.com/res1.jpg",
                            PromptResultText = "Text result for the first prompt.",
                            PromptText = "Prompt text for the first prompt.",
                            ReferenceMaterialImageUrl = "http://example.com/ref1.jpg",
                            ReferenceMaterialText = "Reference text for the first prompt.",
                            UpVotes = 10,
                            UserEmail = "www.supasebie.com",
                            ViewCount = 100
                        },
                        new
                        {
                            Id = new Guid("f8e9b841-e4ad-45ed-a68c-04e5edd375fc"),
                            DownVotes = 1,
                            PostBodyText = "This is the PostBodyText of the second prompt.",
                            PostTitle = "Second Prompt",
                            PromptResultImageUrl = "http://example.com/res2.jpg",
                            PromptResultText = "Text result for the second prompt.",
                            PromptText = "Prompt text for the second prompt.",
                            ReferenceMaterialImageUrl = "http://example.com/ref2.jpg",
                            ReferenceMaterialText = "Reference text for the second prompt.",
                            UpVotes = 20,
                            UserEmail = "",
                            ViewCount = 150
                        },
                        new
                        {
                            Id = new Guid("bbb5a494-3ced-4e39-9bc9-59e1ac8123a1"),
                            DownVotes = 3,
                            PostBodyText = "This is the PostBodyText of the third prompt.",
                            PostTitle = "Third Prompt",
                            PromptResultImageUrl = "http://example.com/res3.jpg",
                            PromptResultText = "Text result for the third prompt.",
                            PromptText = "Prompt text for the third prompt.",
                            ReferenceMaterialImageUrl = "http://example.com/ref3.jpg",
                            ReferenceMaterialText = "Reference text for the third prompt.",
                            UpVotes = 5,
                            UserEmail = "",
                            ViewCount = 50
                        },
                        new
                        {
                            Id = new Guid("a9c3c99e-2ed6-4d9a-bc8d-6a3e9f78b8ac"),
                            DownVotes = 0,
                            PostBodyText = "This is the PostBodyText of the fourth prompt.",
                            PostTitle = "Fourth Prompt",
                            PromptResultImageUrl = "http://example.com/res4.jpg",
                            PromptResultText = "Text result for the fourth prompt.",
                            PromptText = "Prompt text for the fourth prompt.",
                            ReferenceMaterialImageUrl = "http://example.com/ref4.jpg",
                            ReferenceMaterialText = "Reference text for the fourth prompt.",
                            UpVotes = 7,
                            UserEmail = "",
                            ViewCount = 80
                        },
                        new
                        {
                            Id = new Guid("b23b8e91-fef3-4094-ab3b-9e9d563d21b7"),
                            DownVotes = 4,
                            PostBodyText = "This is the PostBodyText of the fifth prompt.",
                            PostTitle = "Fifth Prompt",
                            PromptResultImageUrl = "http://example.com/res5.jpg",
                            PromptResultText = "Text result for the fifth prompt.",
                            PromptText = "Prompt text for the fifth prompt.",
                            ReferenceMaterialImageUrl = "http://example.com/ref5.jpg",
                            ReferenceMaterialText = "Reference text for the fifth prompt.",
                            UpVotes = 15,
                            UserEmail = "",
                            ViewCount = 120
                        },
                        new
                        {
                            Id = new Guid("c4a1f4f8-e5f1-4b71-afac-d15b1b54b6c8"),
                            DownVotes = 2,
                            PostBodyText = "This is the PostBodyText of the sixth prompt.",
                            PostTitle = "Sixth Prompt",
                            PromptResultImageUrl = "http://example.com/res6.jpg",
                            PromptResultText = "Text result for the sixth prompt.",
                            PromptText = "Prompt text for the sixth prompt.",
                            ReferenceMaterialImageUrl = "http://example.com/ref6.jpg",
                            ReferenceMaterialText = "Reference text for the sixth prompt.",
                            UpVotes = 8,
                            UserEmail = "",
                            ViewCount = 90
                        },
                        new
                        {
                            Id = new Guid("d6e9c4d8-f2ab-4aeb-a8fa-2d4ead4c5e99"),
                            DownVotes = 1,
                            PostBodyText = "This is the PostBodyText of the seventh prompt.",
                            PostTitle = "Seventh Prompt",
                            PromptResultImageUrl = "http://example.com/res7.jpg",
                            PromptResultText = "Text result for the seventh prompt.",
                            PromptText = "Prompt text for the seventh prompt.",
                            ReferenceMaterialImageUrl = "http://example.com/ref7.jpg",
                            ReferenceMaterialText = "Reference text for the seventh prompt.",
                            UpVotes = 12,
                            UserEmail = "",
                            ViewCount = 110
                        },
                        new
                        {
                            Id = new Guid("e7d1b8a1-1f23-4df3-ba84-5f9a1d1d4e34"),
                            DownVotes = 3,
                            PostBodyText = "This is the PostBodyText of the eighth prompt.",
                            PostTitle = "Eighth Prompt",
                            PromptResultImageUrl = "http://example.com/res8.jpg",
                            PromptResultText = "Text result for the eighth prompt.",
                            PromptText = "Prompt text for the eighth prompt.",
                            ReferenceMaterialImageUrl = "http://example.com/ref8.jpg",
                            ReferenceMaterialText = "Reference text for the eighth prompt.",
                            UpVotes = 14,
                            UserEmail = "",
                            ViewCount = 130
                        },
                        new
                        {
                            Id = new Guid("f9a2e4b7-2c5b-4fae-8d3b-6b2c1e4b8f4d"),
                            DownVotes = 0,
                            PostBodyText = "This is the PostBodyText of the ninth prompt.",
                            PostTitle = "Ninth Prompt",
                            PromptResultImageUrl = "http://example.com/res9.jpg",
                            PromptResultText = "Text result for the ninth prompt.",
                            PromptText = "Prompt text for the ninth prompt.",
                            ReferenceMaterialImageUrl = "http://example.com/ref9.jpg",
                            ReferenceMaterialText = "Reference text for the ninth prompt.",
                            UpVotes = 9,
                            UserEmail = "",
                            ViewCount = 75
                        },
                        new
                        {
                            Id = new Guid("a5f8e7d9-3a4b-4c7e-9d2f-4b5a1c3e6b8f"),
                            DownVotes = 2,
                            PostBodyText = "This is the PostBodyText of the tenth prompt.",
                            PostTitle = "Tenth Prompt",
                            PromptResultImageUrl = "http://example.com/res10.jpg",
                            PromptResultText = "Text result for the tenth prompt.",
                            PromptText = "Prompt text for the tenth prompt.",
                            ReferenceMaterialImageUrl = "http://example.com/ref10.jpg",
                            ReferenceMaterialText = "Reference text for the tenth prompt.",
                            UpVotes = 18,
                            UserEmail = "",
                            ViewCount = 140
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
