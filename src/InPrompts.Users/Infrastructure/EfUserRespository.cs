using Microsoft.EntityFrameworkCore;

namespace InPrompts.Users;

internal class EfUserRepository(UsersDbContext dbContext) : IEfUserRepository
{
  public Task<AppUser> GetUserWithPostedPrompts(string email) =>
      dbContext.AppUsers
          .Include(user => user.UserPrompts)
          .SingleAsync(user => user.Email == email);

  public Task SaveChangesAsync() => dbContext.SaveChangesAsync();
}