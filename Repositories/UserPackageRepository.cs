using AutoMapper;
using BookingSystem.Entities;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

public class UserPackageRepository : Repository<UserPackage>, IUserPackageRepository 
{
  private readonly IMapper _mapper;

  public UserPackageRepository(BookingSystemContext context, IMapper mapper) : base(context)
  {
    _mapper = mapper;
  }
}