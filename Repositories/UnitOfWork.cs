using BookingSystem.Entities;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookingSystemContext _context;

    public IUserRepository UserRepository { get; }
    public IUserProfileRepository UserProfileRepository { get; }

    public UnitOfWork(BookingSystemContext context, IUserRepository userRepository, IUserProfileRepository userProfileRepository)
    {
        _context = context;
        UserRepository = userRepository;
        UserProfileRepository = userProfileRepository;
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