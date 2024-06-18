﻿// <auto-generated />
using InPrompts.Prompts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InPrompts.Prompts.Data.Migrations
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DownVotes")
                        .HasColumnType("integer");

                    b.Property<string>("ImageResultUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReferenceImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReferenceText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<string>("TextResult")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
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
                            Id = 1,
                            Body = "This is the body of the first prompt.",
                            DownVotes = 2,
                            ImageResultUrl = "http://example.com/res1.jpg",
                            ReferenceImageUrl = "http://example.com/ref1.jpg",
                            ReferenceText = "Reference text for the first prompt.",
                            Text = "Prompt text for the first prompt.",
                            TextResult = "Text result for the first prompt.",
                            Title = "First Prompt",
                            UpVotes = 10,
                            UserEmail = "www.supasebie.com",
                            ViewCount = 100
                        },
                        new
                        {
                            Id = 2,
                            Body = "This is the body of the second prompt.",
                            DownVotes = 1,
                            ImageResultUrl = "http://example.com/res2.jpg",
                            ReferenceImageUrl = "http://example.com/ref2.jpg",
                            ReferenceText = "Reference text for the second prompt.",
                            Text = "Prompt text for the second prompt.",
                            TextResult = "Text result for the second prompt.",
                            Title = "Second Prompt",
                            UpVotes = 20,
                            UserEmail = "",
                            ViewCount = 150
                        },
                        new
                        {
                            Id = 3,
                            Body = "This is the body of the third prompt.",
                            DownVotes = 3,
                            ImageResultUrl = "http://example.com/res3.jpg",
                            ReferenceImageUrl = "http://example.com/ref3.jpg",
                            ReferenceText = "Reference text for the third prompt.",
                            Text = "Prompt text for the third prompt.",
                            TextResult = "Text result for the third prompt.",
                            Title = "Third Prompt",
                            UpVotes = 5,
                            UserEmail = "",
                            ViewCount = 50
                        },
                        new
                        {
                            Id = 4,
                            Body = "This is the body of the fourth prompt.",
                            DownVotes = 0,
                            ImageResultUrl = "http://example.com/res4.jpg",
                            ReferenceImageUrl = "http://example.com/ref4.jpg",
                            ReferenceText = "Reference text for the fourth prompt.",
                            Text = "Prompt text for the fourth prompt.",
                            TextResult = "Text result for the fourth prompt.",
                            Title = "Fourth Prompt",
                            UpVotes = 7,
                            UserEmail = "",
                            ViewCount = 80
                        },
                        new
                        {
                            Id = 5,
                            Body = "This is the body of the fifth prompt.",
                            DownVotes = 4,
                            ImageResultUrl = "http://example.com/res5.jpg",
                            ReferenceImageUrl = "http://example.com/ref5.jpg",
                            ReferenceText = "Reference text for the fifth prompt.",
                            Text = "Prompt text for the fifth prompt.",
                            TextResult = "Text result for the fifth prompt.",
                            Title = "Fifth Prompt",
                            UpVotes = 15,
                            UserEmail = "",
                            ViewCount = 120
                        },
                        new
                        {
                            Id = 6,
                            Body = "This is the body of the sixth prompt.",
                            DownVotes = 2,
                            ImageResultUrl = "http://example.com/res6.jpg",
                            ReferenceImageUrl = "http://example.com/ref6.jpg",
                            ReferenceText = "Reference text for the sixth prompt.",
                            Text = "Prompt text for the sixth prompt.",
                            TextResult = "Text result for the sixth prompt.",
                            Title = "Sixth Prompt",
                            UpVotes = 8,
                            UserEmail = "",
                            ViewCount = 90
                        },
                        new
                        {
                            Id = 7,
                            Body = "This is the body of the seventh prompt.",
                            DownVotes = 1,
                            ImageResultUrl = "http://example.com/res7.jpg",
                            ReferenceImageUrl = "http://example.com/ref7.jpg",
                            ReferenceText = "Reference text for the seventh prompt.",
                            Text = "Prompt text for the seventh prompt.",
                            TextResult = "Text result for the seventh prompt.",
                            Title = "Seventh Prompt",
                            UpVotes = 12,
                            UserEmail = "",
                            ViewCount = 110
                        },
                        new
                        {
                            Id = 8,
                            Body = "This is the body of the eighth prompt.",
                            DownVotes = 3,
                            ImageResultUrl = "http://example.com/res8.jpg",
                            ReferenceImageUrl = "http://example.com/ref8.jpg",
                            ReferenceText = "Reference text for the eighth prompt.",
                            Text = "Prompt text for the eighth prompt.",
                            TextResult = "Text result for the eighth prompt.",
                            Title = "Eighth Prompt",
                            UpVotes = 14,
                            UserEmail = "",
                            ViewCount = 130
                        },
                        new
                        {
                            Id = 9,
                            Body = "This is the body of the ninth prompt.",
                            DownVotes = 0,
                            ImageResultUrl = "http://example.com/res9.jpg",
                            ReferenceImageUrl = "http://example.com/ref9.jpg",
                            ReferenceText = "Reference text for the ninth prompt.",
                            Text = "Prompt text for the ninth prompt.",
                            TextResult = "Text result for the ninth prompt.",
                            Title = "Ninth Prompt",
                            UpVotes = 9,
                            UserEmail = "",
                            ViewCount = 75
                        },
                        new
                        {
                            Id = 10,
                            Body = "This is the body of the tenth prompt.",
                            DownVotes = 2,
                            ImageResultUrl = "http://example.com/res10.jpg",
                            ReferenceImageUrl = "http://example.com/ref10.jpg",
                            ReferenceText = "Reference text for the tenth prompt.",
                            Text = "Prompt text for the tenth prompt.",
                            TextResult = "Text result for the tenth prompt.",
                            Title = "Tenth Prompt",
                            UpVotes = 18,
                            UserEmail = "",
                            ViewCount = 140
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
