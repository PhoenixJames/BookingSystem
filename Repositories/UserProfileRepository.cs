using BookingSystem.Entities;

public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
{
    public UserProfileRepository(BookingSystemContext context) : base(context)
    {
    }
}