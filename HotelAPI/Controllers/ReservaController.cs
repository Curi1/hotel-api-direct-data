using HotelAPI.DTO;

namespace HotelAPI.Controllers;

using HotelAPI.Models;
using HotelAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ReservaController : ControllerBase
{
    private readonly HotelContext _context;

    public ReservaController(HotelContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
    {
        return await _context.Reservas
            .Include(r => r.Cliente)
            .Include(r => r.Quarto)
            .Include(r => r.ReservaStatus)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Reserva>> GetReserva(int id)
    {
        var reserva = await _context.Reservas
            .Include(r => r.Cliente)
            .Include(r => r.Quarto)
            .Include(r => r.ReservaStatus)
            .FirstOrDefaultAsync(r => r.ReservaId == id);

        if (reserva == null)
        {
            return NotFound();
        }

        return reserva;
    }

    [HttpPost]
    public async Task<ActionResult<Reserva>> PostReserva(ReservaDTO reservaDTO)
    {
        var reserva = new Reserva
        {
            ClienteId = reservaDTO.ClienteId,
            QuartoId = reservaDTO.QuartoId,
            ReservaStatusId = reservaDTO.ReservaStatusId,
            DataEntrada = reservaDTO.DataEntrada,
            DataSaida = reservaDTO.DataSaida
        };

        _context.Reservas.Add(reserva);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetReserva", new { id = reserva.ReservaId }, reserva);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutReserva(int id, ReservaDTO reservaDTO)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva == null)
        {
            return NotFound("Reserva não encontrada.");
        }

        reserva.ClienteId = reservaDTO.ClienteId;
        reserva.QuartoId = reservaDTO.QuartoId;
        reserva.ReservaStatusId = reservaDTO.ReservaStatusId;
        reserva.DataEntrada = reservaDTO.DataEntrada;
        reserva.DataSaida = reservaDTO.DataSaida;

        _context.Entry(reserva).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReservaExists(id))
            {
                return NotFound("Reserva não encontrada.");
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReserva(int id)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva == null)
        {
            return NotFound();
        }

        _context.Reservas.Remove(reserva);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ReservaExists(int id)
    {
        return _context.Reservas.Any(e => e.ReservaId == id);
    }
}
