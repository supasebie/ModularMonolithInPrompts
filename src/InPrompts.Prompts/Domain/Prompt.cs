using System.ComponentModel.DataAnnotations;


using Ardalis.GuardClauses;

namespace InPrompts.Prompts;

internal record Prompt
{
    [Key]
    public int Id { get; init; }
    public string UserEmail { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string ReferenceImageUrl { get; set; } = string.Empty;
    public string ImageResultUrl { get; set; } = string.Empty;
    public string ReferenceText { get; set; } = string.Empty;
    public string TextResult { get; set; } = string.Empty;
    public int UpVotes { get; set; } = 0;
    public int DownVotes { get; set; } = 0;
    public int ViewCount { get; set; } = 0;

    internal void UpdateViewCount() => ViewCount++;
    internal void UpdateText(string text) => Text = Guard.Against.NullOrEmpty(text);
}
internal record PromptDto(Guid Id, string UserEmail, string Title, string Body, string Text, string ReferenceImageUrl, string ImageResultUrl, string ReferenceText, string TextResult, int UpVotes, int DownVotes, int ViewCount);

