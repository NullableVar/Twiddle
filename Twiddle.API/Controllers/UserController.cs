using Microsoft.AspNetCore.Mvc;
using Twiddle.API.Core;
using Twiddle.Services.Interfaces;

namespace Twiddle.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService _userService, ITokenProvider _tokenProvider) : ControllerBase
{
    
}
