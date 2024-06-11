
using FastEndpoints;

using Microsoft.AspNetCore.Identity;

namespace InPrompts.Users.UserEndpoints
{
    public record RegisterUserRequest(string Email, string Password);

    internal class Create(UserManager<ApplicationUser> userManager) : Endpoint<RegisterUserRequest>
    {
        public override void Configure()
        {
            Post("/users");
            AllowAnonymous();
        }

        public override async Task HandleAsync(RegisterUserRequest req, CancellationToken ct)
        {
            var user = new ApplicationUser { Email = req.Email, UserName = req.Email };

            var result = await userManager.CreateAsync(user, req.Password);
            if (!result.Succeeded)
            {
                var problems = new ProblemDetails
                {
                    Errors = result.Errors.Select(x =>
                        new ProblemDetails.Error { Code = x.Code, Reason = x.Description, Name = x.Code }),
                    Detail = "Could not register user."
                };
                await SendAsync(problems, 400, ct);
                return;
            }

            await SendOkAsync(ct);
        }
    }
}
