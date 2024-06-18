using System.ComponentModel.DataAnnotations;

namespace InPrompts.Users;

public record UserPrompt
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
    public bool Deleted { get; set; } = false;

    public UserPrompt() { }
}