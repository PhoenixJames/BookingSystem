public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    // Add other repositories as needed

    Task SaveChangesAsync();
}