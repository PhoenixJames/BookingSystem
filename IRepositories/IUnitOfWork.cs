public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }

    IUserProfileRepository UserProfileRepository { get; }
    Task SaveChangesAsync();
}