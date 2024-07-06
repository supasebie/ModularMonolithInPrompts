namespace InPrompts.EventBus;

public record SendWelcomeEmailCommand(Guid UserId, string Email);

public record NewUserRegisteredCommand(Guid UserId, string Email);