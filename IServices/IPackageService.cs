using BookingSystem.Entities;
using BookingSystem.Models;

public interface IPackageService 
{
    Task<List<Package>> GetAllPackage();
    Task<List<Package>> GetPackagesByCountry(string country);
    Task<UserPackage> PurchasePackage(PurchasePackageModel userPackage);

}