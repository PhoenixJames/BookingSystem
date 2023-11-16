using AutoMapper;
using BookingSystem.Entities;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

public class UserClassRepository : Repository<UserClass>, IUserClassRepository 
{
  private readonly IMapper _mapper;

  public UserClassRepository(BookingSystemContext context, IMapper mapper) : base(context)
  {
    _mapper = mapper;
  }
}