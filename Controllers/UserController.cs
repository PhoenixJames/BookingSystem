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
public class UserController : ControllerBase
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  private readonly IConfiguration _config;


  public UserController(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
    _config = config;
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
  public async Task<IActionResult> RegisterUser([FromBody] UserRegisterModel userData)
  {
    try
    {
      if (userData == null)
      {
        return BadRequest("User object is null");
      }
      User user = _mapper.Map<User>(userData);
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
  [HttpPost("login")]
  [AllowAnonymous]
  public async Task<IActionResult> Login([FromBody] UserLoginModel loginRequest)
  {
    try
    {
      // Validate the request
      if (loginRequest == null || string.IsNullOrEmpty(loginRequest.UserName) || string.IsNullOrEmpty(loginRequest.Password))
      {
        return BadRequest("Invalid login request");
      }

      // Authenticate the user
      UserModel user = await _unitOfWork.UserRepository.GetUserByUsernameAndPasswordAsync(loginRequest.UserName, loginRequest.Password);

      if (user != null)
      {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
          _config["Jwt:Issuer"],
          null,
          expires: DateTime.Now.AddMinutes(120),
          signingCredentials: credentials);

        var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
        user.AccessToken = token;
        return Ok(user);
      }
      else
      {
        // Invalid username or password
        return Unauthorized("Invalid username or password");
      }
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }
}