
using InPrompts.SharedKernel;

namespace InPrompts.Users.Contracts;

public record NewUserRegistered(NewUserDetails Details) : IntegrationEventBase;
