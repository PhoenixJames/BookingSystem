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
public class ClassController : ControllerBase
{
  private readonly IClassService _classService;


  public ClassController
  (
    IClassService classService
  )
  {
    _classService = classService;
  }

  [HttpGet("getAllPackage")]
  public async Task<IActionResult> GetAllPackage()
  {
    try
    {
      List<Class> classes = await _classService.GetAllClass();
      if (classes.Count() == 0)
      {
        return Ok("No Record Found");
      }
      return Ok(classes);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }
}