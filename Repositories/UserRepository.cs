using AutoMapper;
using BookingSystem.Entities;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepository : Repository<User>, IUserRepository
{
  private readonly IMapper _mapper;

  public UserRepository(BookingSystemContext context, IMapper mapper) : base(context)
  {
    _mapper = mapper;
  }

  public async Task<UserModel> GetUserByUsernameAndPasswordAsync(string username, string password)
  {
    try
    {
      User user = await Query().Where(u => u.UserName == username && u.Password == password && u.IsActive == true).FirstOrDefaultAsync();
      if (user != null && user.IsActive == false) {
        throw new Exception("User is not active");
      }
      return _mapper.Map<UserModel>(user);
    }
    catch (System.Exception)
    {

      throw;
    }
  }
}