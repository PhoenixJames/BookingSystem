using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BookingSystem.Entities;
using BookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PackageController : ControllerBase
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  private readonly IConfiguration _config;


  public PackageController(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
    _config = config;
  }

  [HttpGet("getAllPackage")]
  public async Task<IActionResult> GetAllPackage()
  {
    try
    {
      var users = await _unitOfWork.PackageRepository.GetAllAsync();
      return Ok(users);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }

  [HttpGet("getPackagesByCountry")]
  public async Task<IActionResult> GetPackagesByCountry(string country)
  {
    try
    {
      var users = await _unitOfWork.PackageRepository
        .Query()
        .Where(p => p.Country == country).ToListAsync();
      return Ok(users);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }

  [HttpPost("purchasePackage")]
  public async Task<IActionResult> PurchasePackage([FromBody] PurchasePackageModel req)
  {
    try
    {
      if (req == null)
      {
        return BadRequest("req body is null.");
      }
      User user = _mapper.Map<User>(userData);
      user.IsActive = false;
      UserProfile userProfile = _mapper.Map<UserProfile>(userData);
      await _unitOfWork.UserRepository.AddAsync(user);
      // await _unitOfWork.SaveChangesAsync();
      await _unitOfWork.UserProfileRepository.AddAsync(userProfile);
      await _unitOfWork.SaveChangesAsync();


      var newUser = await _unitOfWork.UserRepository.GetByIdAsync(user.UserId);
      return Ok(newUser);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }

}