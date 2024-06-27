namespace InPrompts.Users;

internal interface IEfUserRepository
{
    Task<AppUser> GetUserWithPostedPrompts(string email);
    Task SaveChangesAsync();
}
