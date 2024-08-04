namespace HotelAPI.Controllers;

using HotelAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class QuartoController : ControllerBase
{
    private readonly HotelContext _context;

    public QuartoController(HotelContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Quarto>>> GetQuartos()
    {
        return await _context.Quartos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Quarto>> GetQuarto(int id)
    {
        var quarto = await _context.Quartos.FindAsync(id);

        if (quarto == null)
        {
            return NotFound();
        }

        return quarto;
    }

    [HttpPost]
    public async Task<ActionResult<Quarto>> PostQuarto(Quarto quarto)
    {
        _context.Quartos.Add(quarto);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetQuarto", new { id = quarto.QuartoId }, quarto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutQuarto(int id, Quarto quarto)
    {
        if (id != quarto.QuartoId)
        {
            return BadRequest();
        }

        _context.Entry(quarto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!QuartoExists(id))
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
    public async Task<IActionResult> DeleteQuarto(int id)
    {
        var quarto = await _context.Quartos.FindAsync(id);
        if (quarto == null)
        {
            return NotFound();
        }

        _context.Quartos.Remove(quarto);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool QuartoExists(int id)
    {
        return _context.Quartos.Any(e => e.QuartoId == id);
    }
}
