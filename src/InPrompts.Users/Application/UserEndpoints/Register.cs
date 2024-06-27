using FastEndpoints;
using FastEndpoints.Security;

using MediatR;

namespace InPrompts.Users.UserEndpoints
{
    public record RegisterUserRequest(string Email, string Password);
    public record RegisterUserResponse(string Token);

    internal class Register(IMediator mediator) : Endpoint<RegisterUserRequest, RegisterUserResponse>
    {
        public override void Configure()
        {
            Post("/users");
            AllowAnonymous();
        }

        public override async Task HandleAsync(RegisterUserRequest req, CancellationToken ct)
        {
            var command = new CreateUserCommand(req.Email, req.Password);
            var response = await mediator.Send(command, ct);

            if (response.IsSuccess)
            {
                var jwtSecret = Config["Auth:JwtSecret"]!;
                var token = JwtBearer.CreateToken(o =>
                {
                    o.SigningKey = jwtSecret;
                    o.User["EmailAddress"] = req.Email!;
                });

                await SendAsync(new RegisterUserResponse(token));
            }
        }
    }
}
