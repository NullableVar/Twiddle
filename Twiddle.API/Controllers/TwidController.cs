using Microsoft.AspNetCore.Mvc;
using Twiddle.Models;
using Twiddle.Services.Interfaces;

namespace Twiddle.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TwidController(ITwidService _twidService) : ControllerBase
{
    // GET: api/Twid
    [HttpGet]
    public async Task<ActionResult<IList<TwidModel>>> GetAll()
    {
        var twids = await _twidService.GetAllAsync();
        return Ok(twids);
    }

    // GET: api/Twid/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TwidModel>> GetById(Guid id)
    {
        var twid = await _twidService.GetByIdAsync(id);
        if (twid == null)
            return NotFound();

        return Ok(twid);
    }

    // GET: api/Twid/User/{userId}
    [HttpGet("User/{userId:guid}")]
    public async Task<ActionResult<IList<TwidModel>>> GetByUserId(Guid userId)
    {
        var twids = await _twidService.GetByUserIdAsync(userId);
        return Ok(twids);
    }

    // POST: api/Twid
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] TwidModel twidModel)
    {
        await _twidService.CreateAsync(twidModel);
        return CreatedAtAction(nameof(GetById), new { id = twidModel.Id }, twidModel);
    }

    // PUT: api/Twid/{id}
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] TwidModel twidModel)
    {
        if (id != twidModel.Id)
            return BadRequest("Id mismatch between URL and body");

        await _twidService.UpdateAsync(twidModel);
        return NoContent();
    }
}