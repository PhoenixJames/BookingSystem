using BookingSystem.Entities;
using BookingSystem.Models;

public interface IUserRepository : IRepository<User>
{
  Task<UserModel> GetUserByUsernameAndPasswordAsync(string username, string password);

}