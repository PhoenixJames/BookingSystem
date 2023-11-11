using BookingSystem.Entities;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(BookingSystemContext context) : base(context)
    {
    }
}