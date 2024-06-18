using Ardalis.Result;

using MediatR;

namespace InPrompts.Prompts.Contracts;

public record PostPromptCommand(PostPromptRequest postedPrompt) : IRequest<Result<PostPromptResponse>>;

public record PostPromptResponse
{
  public Guid Id { get; init; } = Guid.NewGuid();
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
}

public record PostPromptRequest
{
  public Guid Id { get; init; } = Guid.NewGuid();
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
}