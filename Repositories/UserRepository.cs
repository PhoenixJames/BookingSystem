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
    User user = await Query().Where(u => u.UserName == username && u.Password == password).FirstOrDefaultAsync();
    return _mapper.Map<UserModel>(user);
  }
}