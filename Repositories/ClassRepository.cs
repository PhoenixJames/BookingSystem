using AutoMapper;
using BookingSystem.Entities;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

public class ClassRepository : Repository<Class>, IClassRepository 
{
  private readonly IMapper _mapper;

  public ClassRepository(BookingSystemContext context, IMapper mapper) : base(context)
  {
    _mapper = mapper;
  }
}