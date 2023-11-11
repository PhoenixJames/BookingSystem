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