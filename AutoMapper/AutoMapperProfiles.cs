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
    }
}