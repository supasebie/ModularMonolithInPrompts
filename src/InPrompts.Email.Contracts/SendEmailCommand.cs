using Ardalis.Result;

using MediatR;

namespace InPrompts.Email.Contracts;

public record SendEmailCommand(string To, string From, string Subject, string Body) : IRequest<Result<Guid>>;