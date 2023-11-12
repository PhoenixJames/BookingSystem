using AutoMapper;
using BookingSystem.Entities;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

public class PackageRepository : Repository<Package>, IPackageRepository 
{
  private readonly IMapper _mapper;

  public PackageRepository(BookingSystemContext context, IMapper mapper) : base(context)
  {
    _mapper = mapper;
  }
}