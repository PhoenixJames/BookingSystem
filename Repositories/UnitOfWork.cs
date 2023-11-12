using BookingSystem.Entities;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookingSystemContext _context;

    public IUserRepository UserRepository { get; }
    public IUserProfileRepository UserProfileRepository { get; }
    public IPackageRepository PackageRepository { get; }
    public IClassRepository ClassRepository { get; }
    public IWaitlistRepository WaitlistRepository { get; }

    public UnitOfWork(
      BookingSystemContext context,
      IUserRepository userRepository,
      IUserProfileRepository userProfileRepository,
      IPackageRepository packageRepository,
      IClassRepository classRepository,
      IWaitlistRepository waitlistRepository
    )
    {
        _context = context;
        UserRepository = userRepository;
        UserProfileRepository = userProfileRepository;
        PackageRepository = packageRepository;
        ClassRepository = classRepository;
        WaitlistRepository = waitlistRepository;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}