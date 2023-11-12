using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BookingSystem.Entities;
using BookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Authorization;

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

}