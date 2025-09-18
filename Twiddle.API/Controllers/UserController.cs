using Microsoft.AspNetCore.Mvc;
using Twiddle.API.Core;
using Twiddle.Models;
using Twiddle.Services.Interfaces;

namespace Twiddle.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService _userService, ITokenProvider _tokenProvider) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserModel userModel)
    {
        var result = await _userService.RegisterAsync(userModel);
        
        if (!result) 
            return BadRequest("User already exists.");

        return Ok("User created.");
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserModel userModel)
    {
        var result = await _userService.LoginAsync(userModel);
        
        if (!result) 
            return BadRequest("Wrong login data.");
        
        var token = _tokenProvider.Create(userModel);
        return Ok(token);
    }
}
