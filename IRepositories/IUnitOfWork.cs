public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }

    IUserProfileRepository UserProfileRepository { get; }
    IPackageRepository PackageRepository { get; }
    IClassRepository ClassRepository { get; }
    IWaitlistRepository WaitlistRepository { get; }
    Task SaveChangesAsync();
}