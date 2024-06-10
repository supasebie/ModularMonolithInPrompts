using Ardalis.GuardClauses;

namespace InPrompts.Prompts;

internal record Prompt
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Text { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public int ViewCount { get; set; } = 0;
    internal Prompt(Guid id, string text, string user, int viewCount)
    {
        Id = Guard.Against.Default(id);
        Text = Guard.Against.NullOrEmpty(text);
        User = Guard.Against.NullOrEmpty(user);
        ViewCount = Guard.Against.Negative(viewCount);
    }

    internal void UpdateViewCount() => ViewCount++;
    internal void UpdateText(string text) => Text = Guard.Against.NullOrEmpty(text);
}
internal record PromptDto(Guid Id, string Text, string User, int ViewCount);
