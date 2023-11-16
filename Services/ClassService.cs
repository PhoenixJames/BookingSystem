using AutoMapper;
using BookingSystem.Entities;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

public class ClassService : IClassService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  private readonly IConfiguration _config;

  public ClassService
  (
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IConfiguration config
  )
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
    _config = config;
  }

  public async Task<List<Class>> GetAllClass()
  {
    try
    {
      IEnumerable<Class> classes = await _unitOfWork.ClassRepository.GetAllAsync();
      return classes.ToList<Class>();
    }
    catch (System.Exception)
    {
      throw;
    }
  }
}