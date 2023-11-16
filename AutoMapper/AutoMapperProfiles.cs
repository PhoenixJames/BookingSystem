using AutoMapper;
using BookingSystem.Entities;
using BookingSystem.Models;
namespace BookingSystem.AutoMapper;
public class UserMappingProfile : Profile 
{
    public UserMappingProfile()
    {
        CreateMap<UserRegisterModel, User>();
        CreateMap<User, UserRegisterModel>();

        CreateMap<UserModel, User>();
        CreateMap<User, UserModel>();

        CreateMap<EmailVerifyModel, User>();
        CreateMap<User, EmailVerifyModel>();
    }
}
public class UserProfileMappingProfile : Profile 
{
    public UserProfileMappingProfile()
    {
        CreateMap<UserRegisterModel, UserProfile>();
        CreateMap<UserProfile, UserRegisterModel>();
    }
}
public class UserPackageMappingProfile : Profile 
{
    public UserPackageMappingProfile()
    {
        CreateMap<PurchasePackageModel, UserPackage>();
        CreateMap<UserPackage, PurchasePackageModel>();
    }
}