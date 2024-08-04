namespace HotelAPI.Controllers;

using HotelAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ReservaStatusController : ControllerBase
{
    private readonly HotelContext _context;

    public ReservaStatusController(HotelContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservaStatus>>> GetReservaStatus()
    {
        return await _context.ReservaStatus.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReservaStatus>> GetReservaStatus(int id)
    {
        var reservaStatus = await _context.ReservaStatus.FindAsync(id);

        if (reservaStatus == null)
        {
            return NotFound();
        }

        return reservaStatus;
    }

    [HttpPost]
    public async Task<ActionResult<ReservaStatus>> PostReservaStatus(ReservaStatus reservaStatus)
    {
        _context.ReservaStatus.Add(reservaStatus);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetReservaStatus", new { id = reservaStatus.ReservaStatusId }, reservaStatus);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutReservaStatus(int id, ReservaStatus reservaStatus)
    {
        if (id != reservaStatus.ReservaStatusId)
        {
            return BadRequest();
        }

        _context.Entry(reservaStatus).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReservaStatusExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservaStatus(int id)
    {
        var reservaStatus = await _context.ReservaStatus.FindAsync(id);
        if (reservaStatus == null)
        {
            return NotFound();
        }

        _context.ReservaStatus.Remove(reservaStatus);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ReservaStatusExists(int id)
    {
        return _context.ReservaStatus.Any(e => e.ReservaStatusId == id);
    }
}
