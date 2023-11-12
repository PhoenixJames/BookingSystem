using AutoMapper;
using BookingSystem.Entities;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

public class WaitlistRepository : Repository<Waitlist>, IWaitlistRepository 
{
  private readonly IMapper _mapper;

  public WaitlistRepository(BookingSystemContext context, IMapper mapper) : base(context)
  {
    _mapper = mapper;
  }
}