using System.ComponentModel.DataAnnotations;

using Ardalis.GuardClauses;

namespace InPrompts.Prompts;

internal record Prompt
{
    [Key]
    public Guid Id { get; init; }
    public string UserEmail { get; set; } = string.Empty;
    public string PostTitle { get; set; } = string.Empty;
    public string PostBodyText { get; set; } = string.Empty;
    public string PromptText { get; set; } = string.Empty;
    public string ReferenceMaterialImageUrl { get; set; } = string.Empty;
    public string ReferenceMaterialText { get; set; } = string.Empty;
    public string PromptResultImageUrl { get; set; } = string.Empty;
    public string PromptResultText { get; set; } = string.Empty;
    public int UpVotes { get; set; } = 0;
    public int DownVotes { get; set; } = 0;
    public int ViewCount { get; set; } = 0;

    internal void UpdateViewCount() => ViewCount++;
    internal void UpdateText(string text) => PromptText = Guard.Against.NullOrEmpty(text);
}
internal record CreatePromptDto
{
    public string UserEmail { get; set; } = string.Empty;
    public string PostTitle { get; set; } = string.Empty;
    public string PostBodyText { get; set; } = string.Empty;
    public string PromptText { get; set; } = string.Empty;
    public string ReferenceMaterialImageUrl { get; set; } = string.Empty;
    public string ReferenceMaterialText { get; set; } = string.Empty;
    public string PromptResultImageUrl { get; set; } = string.Empty;
    public string PromptResultText { get; set; } = string.Empty;
}

internal record PromptResponseDto
{
    public Guid Id { get; init; }
    public string UserEmail { get; set; } = string.Empty;
    public string PostTitle { get; set; } = string.Empty;
    public string PostBodyText { get; set; } = string.Empty;
    public string PromptText { get; set; } = string.Empty;
    public string ReferenceMaterialImageUrl { get; set; } = string.Empty;
    public string ReferenceMaterialText { get; set; } = string.Empty;
    public string PromptResultImageUrl { get; set; } = string.Empty;
    public string PromptResultText { get; set; } = string.Empty;
    public int UpVotes { get; set; } = 0;
    public int DownVotes { get; set; } = 0;
    public int ViewCount { get; set; } = 0;
}
