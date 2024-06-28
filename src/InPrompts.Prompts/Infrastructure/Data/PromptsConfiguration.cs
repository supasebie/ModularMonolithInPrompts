using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InPrompts.Prompts;

internal class PromptsConfiguration : IEntityTypeConfiguration<Prompt>
{
  public void Configure(EntityTypeBuilder<Prompt> builder)
  {
    builder.Property(t => t.PromptText).HasMaxLength(DataSchemaConstants.TEXT_MAX_LENGTH);
    builder.HasData(GetSamplePromptsData());
  }

  internal static readonly Guid Prompt1Id = new("DFFE455B-8F20-4B08-9EC5-3B4A1FFC4D18");
  internal static readonly Guid Prompt2Id = new("F8E9B841-E4AD-45ED-A68C-04E5EDD375FC");
  internal static readonly Guid Prompt3Id = new("BBB5A494-3CED-4E39-9BC9-59E1AC8123A1");
  internal static readonly Guid Prompt4Id = new("A9C3C99E-2ED6-4D9A-BC8D-6A3E9F78B8AC");
  internal static readonly Guid Prompt5Id = new("B23B8E91-FEF3-4094-AB3B-9E9D563D21B7");
  internal static readonly Guid Prompt6Id = new("C4A1F4F8-E5F1-4B71-AFAC-D15B1B54B6C8");
  internal static readonly Guid Prompt7Id = new("D6E9C4D8-F2AB-4AEB-A8FA-2D4EAD4C5E99");
  internal static readonly Guid Prompt8Id = new("E7D1B8A1-1F23-4DF3-BA84-5F9A1D1D4E34");
  internal static readonly Guid Prompt9Id = new("F9A2E4B7-2C5B-4FAE-8D3B-6B2C1E4B8F4D");
  internal static readonly Guid Prompt10Id = new("A5F8E7D9-3A4B-4C7E-9D2F-4B5A1C3E6B8F");

  // internal static readonly int Prompt1Id = 1;
  // internal static readonly int Prompt2Id = 2;
  // internal static readonly int Prompt3Id = 3;
  // internal static readonly int Prompt4Id = 4;
  // internal static readonly int Prompt5Id = 5;
  // internal static readonly int Prompt6Id = 6;
  // internal static readonly int Prompt7Id = 7;
  // internal static readonly int Prompt8Id = 8;
  // internal static readonly int Prompt9Id = 9;
  // internal static readonly int Prompt10Id = 10;

  private IEnumerable<Prompt> GetSamplePromptsData()
  {
    yield return new Prompt
    {
      Id = Prompt1Id,
      UserEmail = "www.supasebie.com",
      PostTitle = "First Prompt",
      PostBodyText = "This is the body of the first prompt.",
      PromptText = "Prompt text for the first prompt.",
      ReferenceMaterialImageUrl = "http://example.com/ref1.jpg",
      ReferenceMaterialText = "Reference text for the first prompt.",
      PromptResultImageUrl = "http://example.com/res1.jpg",
      PromptResultText = "Text result for the first prompt.",
      UpVotes = 10,
      DownVotes = 2,
      ViewCount = 100
    };

    yield return new Prompt
    {
      Id = Prompt2Id,
      UserEmail = string.Empty,
      PostTitle = "Second Prompt",
      PostBodyText = "This is the PostBodyText of the second prompt.",
      PromptText = "Prompt text for the second prompt.",
      ReferenceMaterialImageUrl = "http://example.com/ref2.jpg",
      PromptResultImageUrl = "http://example.com/res2.jpg",
      ReferenceMaterialText = "Reference text for the second prompt.",
      PromptResultText = "Text result for the second prompt.",
      UpVotes = 20,
      DownVotes = 1,
      ViewCount = 150
    };

    yield return new Prompt
    {
      Id = Prompt3Id,
      UserEmail = string.Empty,
      PostTitle = "Third Prompt",
      PostBodyText = "This is the PostBodyText of the third prompt.",
      PromptText = "Prompt text for the third prompt.",
      ReferenceMaterialImageUrl = "http://example.com/ref3.jpg",
      PromptResultImageUrl = "http://example.com/res3.jpg",
      ReferenceMaterialText = "Reference text for the third prompt.",
      PromptResultText = "Text result for the third prompt.",
      UpVotes = 5,
      DownVotes = 3,
      ViewCount = 50
    };

    yield return new Prompt
    {
      Id = Prompt4Id,
      UserEmail = string.Empty,
      PostTitle = "Fourth Prompt",
      PostBodyText = "This is the PostBodyText of the fourth prompt.",
      PromptText = "Prompt text for the fourth prompt.",
      ReferenceMaterialImageUrl = "http://example.com/ref4.jpg",
      PromptResultImageUrl = "http://example.com/res4.jpg",
      ReferenceMaterialText = "Reference text for the fourth prompt.",
      PromptResultText = "Text result for the fourth prompt.",
      UpVotes = 7,
      DownVotes = 0,
      ViewCount = 80
    };

    yield return new Prompt
    {
      Id = Prompt5Id,
      UserEmail = string.Empty,
      PostTitle = "Fifth Prompt",
      PostBodyText = "This is the PostBodyText of the fifth prompt.",
      PromptText = "Prompt text for the fifth prompt.",
      ReferenceMaterialImageUrl = "http://example.com/ref5.jpg",
      PromptResultImageUrl = "http://example.com/res5.jpg",
      ReferenceMaterialText = "Reference text for the fifth prompt.",
      PromptResultText = "Text result for the fifth prompt.",
      UpVotes = 15,
      DownVotes = 4,
      ViewCount = 120
    };

    yield return new Prompt
    {
      Id = Prompt6Id,
      UserEmail = string.Empty,
      PostTitle = "Sixth Prompt",
      PostBodyText = "This is the PostBodyText of the sixth prompt.",
      PromptText = "Prompt text for the sixth prompt.",
      ReferenceMaterialImageUrl = "http://example.com/ref6.jpg",
      PromptResultImageUrl = "http://example.com/res6.jpg",
      ReferenceMaterialText = "Reference text for the sixth prompt.",
      PromptResultText = "Text result for the sixth prompt.",
      UpVotes = 8,
      DownVotes = 2,
      ViewCount = 90
    };

    yield return new Prompt
    {
      Id = Prompt7Id,
      UserEmail = string.Empty,
      PostTitle = "Seventh Prompt",
      PostBodyText = "This is the PostBodyText of the seventh prompt.",
      PromptText = "Prompt text for the seventh prompt.",
      ReferenceMaterialImageUrl = "http://example.com/ref7.jpg",
      PromptResultImageUrl = "http://example.com/res7.jpg",
      ReferenceMaterialText = "Reference text for the seventh prompt.",
      PromptResultText = "Text result for the seventh prompt.",
      UpVotes = 12,
      DownVotes = 1,
      ViewCount = 110
    };

    yield return new Prompt
    {
      Id = Prompt8Id,
      UserEmail = string.Empty,
      PostTitle = "Eighth Prompt",
      PostBodyText = "This is the PostBodyText of the eighth prompt.",
      PromptText = "Prompt text for the eighth prompt.",
      ReferenceMaterialImageUrl = "http://example.com/ref8.jpg",
      PromptResultImageUrl = "http://example.com/res8.jpg",
      ReferenceMaterialText = "Reference text for the eighth prompt.",
      PromptResultText = "Text result for the eighth prompt.",
      UpVotes = 14,
      DownVotes = 3,
      ViewCount = 130
    };

    yield return new Prompt
    {
      Id = Prompt9Id,
      UserEmail = string.Empty,
      PostTitle = "Ninth Prompt",
      PostBodyText = "This is the PostBodyText of the ninth prompt.",
      PromptText = "Prompt text for the ninth prompt.",
      ReferenceMaterialImageUrl = "http://example.com/ref9.jpg",
      PromptResultImageUrl = "http://example.com/res9.jpg",
      ReferenceMaterialText = "Reference text for the ninth prompt.",
      PromptResultText = "Text result for the ninth prompt.",
      UpVotes = 9,
      DownVotes = 0,
      ViewCount = 75
    };

    yield return new Prompt
    {
      Id = Prompt10Id,
      UserEmail = string.Empty,
      PostTitle = "Tenth Prompt",
      PostBodyText = "This is the PostBodyText of the tenth prompt.",
      PromptText = "Prompt text for the tenth prompt.",
      ReferenceMaterialImageUrl = "http://example.com/ref10.jpg",
      PromptResultImageUrl = "http://example.com/res10.jpg",
      ReferenceMaterialText = "Reference text for the tenth prompt.",
      PromptResultText = "Text result for the tenth prompt.",
      UpVotes = 18,
      DownVotes = 2,
      ViewCount = 140
    };
  }

  public static class DataSchemaConstants
  {
    public const int TEXT_MAX_LENGTH = 5000;
  }

}