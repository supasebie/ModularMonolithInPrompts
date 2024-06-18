
// using Ardalis.Result;

// using MediatR;


// namespace InPrompts.Users;

// public record ListUserPromptsQuery(string email) : IRequest<Result<List<UserPrompt>>>;

// internal class ListUserPromptsQueryHandler(IAppUserRepository userRepository) : IRequestHandler<ListUserPromptsQuery, Result<List<UserPrompt>>>
// {
//   public async Task<Result<List<UserPrompt>>> Handle(ListUserPromptsQuery request, CancellationToken cancellationToken)
//   {

//     var user = await userRepository.GetUserWithPostedPrompts(request.email);

//     if (user is null)
//     {
//       return Result.Unauthorized();
//     }

//     var postedPrompts = user.UserPrompts.Select(UserPrompt => new UserPrompt
//     {
//       Id = UserPrompt.Id,
//       AppUserEmail = UserPrompt.AppUserEmail,
//       Title = UserPrompt.Title,
//       Body = UserPrompt.Body,
//       Text = UserPrompt.Text,
//       ReferenceImageUrl = UserPrompt.ReferenceImageUrl,
//       ImageResultUrl = UserPrompt.ImageResultUrl,
//       ReferenceText = UserPrompt.ReferenceText,
//       TextResult = UserPrompt.TextResult,
//       UpVotes = UserPrompt.UpVotes,
//       DownVotes = UserPrompt.DownVotes,
//       ViewCount = UserPrompt.ViewCount,
//       Deleted = UserPrompt.Deleted
//     }).ToList();

//     return postedPrompts;
//   }

// }