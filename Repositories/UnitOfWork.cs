using BookingSystem.Entities;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookingSystemContext _context;

    public IUserRepository UserRepository { get; }

    public UnitOfWork(BookingSystemContext context, IUserRepository userRepository)
    {
        _context = context;
        UserRepository = userRepository;
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