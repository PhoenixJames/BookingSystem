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
  private readonly IPackageService _packageService;


  public PackageController
  (
    IPackageService packageService
  )
  {
    _packageService = packageService;
  }

  [HttpGet("getAllPackage")]
  public async Task<IActionResult> GetAllPackage()
  {
    try
    {
      List<Package> packages = await _packageService.GetAllPackage();
      if (packages.Count() == 0)
      {
        return Ok("No Record Found");
      }
      return Ok(packages);
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
      List<Package> packages = await _packageService.GetPackagesByCountry(country);
      if (packages.Count() == 0)
      {
        return Ok("No Record Found");
      }
      return Ok(packages);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }

  [HttpPost("purchasePackage")]
  public async Task<IActionResult> PurchasePackage([FromBody] PurchasePackageModel reqBody)
  {
    try
    {
      if (reqBody == null)
      {
        return BadRequest("req body is null.");
      }
      await _packageService.PurchasePackage(reqBody);
      return Ok("Package Purchase Successful.");
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }

}