using AutoMapper;
using BookingSystem.Entities;
using BookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;


  public UserController(IUnitOfWork unitOfWork, IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  [HttpGet]
  public async Task<IActionResult> GetAllUsers()
  {
    try
    {
      var users = await _unitOfWork.UserRepository.GetAllAsync();
      return Ok(users);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetUserById(int id)
  {
    try
    {
      var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

      if (user == null)
      {
        return NotFound($"User with ID {id} not found");
      }

      return Ok(user);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }

  [HttpPost]
  public async Task<IActionResult> AddUser([FromBody] UserRegisterModel userData)
  {
    try
    {
      if (userData == null)
      {
        return BadRequest("User object is null");
      }
      var user = _mapper.Map<User>(userData);
      await _unitOfWork.UserRepository.AddAsync(user);
      await _unitOfWork.SaveChangesAsync();

      return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }
}