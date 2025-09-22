using Microsoft.AspNetCore.Mvc;
using Twiddle.API.Controllers.Requests;
using Twiddle.API.Core;
using Twiddle.Models;
using Twiddle.Services.Interfaces;

namespace Twiddle.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService _userService, ITokenProvider _tokenProvider) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var user = new UserModel
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            CreatedAt = DateTime.UtcNow
        };

        var result = await _userService.RegisterAsync(user);
        if (!result) return BadRequest("User already exists.");

        return Ok("User created.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var tmp = new UserModel { Email = request.Email, Password = request.Password };
        var ok = await _userService.LoginAsync(tmp);
        if (!ok) return BadRequest("Wrong login data.");

        var token = _tokenProvider.Create(tmp);
        return Ok(token);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _userService.GetByIdAsync(id);
        return user is null ? NotFound() : Ok(user);
    }
    
    
    [HttpGet("by-email")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return BadRequest("Email must be provided.");

        var user = await _userService.GetByEmailAsync(email);
        if (user is null)
            return NotFound("User not found.");

        return Ok(user);
    }
}