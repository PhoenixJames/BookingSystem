using AutoMapper;
using BookingSystem.Entities;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

public class PackageService : IPackageService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  private readonly IConfiguration _config;

  public PackageService
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

  public async Task<List<Package>> GetAllPackage()
  {
    try
    {
      IEnumerable<Package> packages = await _unitOfWork.PackageRepository.GetAllAsync();
      return packages.ToList<Package>();
    }
    catch (System.Exception)
    {
      throw;
    }
  }
  public async Task<List<Package>> GetPackagesByCountry(string country)
  {
    try
    {
      List<Package> packages = await _unitOfWork.PackageRepository
        .Query()
        .Where(p => p.Country == country && p.IsActive == true).ToListAsync();
      return packages;
    }
    catch (System.Exception)
    {
      throw;
    }
  }

  public async Task<UserPackage> PurchasePackage(PurchasePackageModel userPackage)
  {
    try
    {
      User user = await _unitOfWork.UserRepository.GetByIdAsync(userPackage.UserId);
      Package package = await _unitOfWork.PackageRepository.GetByIdAsync(userPackage.PackageId);
      if (user.Country != package.Country) {
        throw new Exception("User only purchase same country package");
      }
      userPackage.UserCredits = package.Credits; 
      userPackage.ExpiryDate = DateTime.Now.AddDays(package.Duration);
      userPackage.PurchaseDate = DateTime.Now;
      userPackage.CreatedDate = DateTime.Now;
      userPackage.UpdatedDate = DateTime.Now;
      UserPackage userPackageModel = _mapper.Map<UserPackage>(userPackage);
      await _unitOfWork.UserPackageRepository.AddAsyncWithSaveChanges(userPackageModel);
      return userPackageModel;
    }
    catch (System.Exception)
    {

      throw;
    }
  }
}