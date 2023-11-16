public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }

    IUserProfileRepository UserProfileRepository { get; }
    IUserPackageRepository UserPackageRepository { get; }
    IUserClassRepository UserClassRepository { get; }
    IPackageRepository PackageRepository { get; }
    IClassRepository ClassRepository { get; }
    IWaitlistRepository WaitlistRepository { get; }
    Task SaveChangesAsync();
}