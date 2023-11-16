using BookingSystem.Entities;
using BookingSystem.Models;

public interface IClassService 
{
    Task<List<Class>> GetAllClass();
}