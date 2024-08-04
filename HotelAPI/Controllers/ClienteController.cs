﻿namespace HotelAPI.Controllers;
using HotelAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly HotelContext _context;

    public ClienteController(HotelContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
    {
        return await _context.Clientes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return cliente;
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCliente(int id, Cliente cliente)
    {
        if (id != cliente.ClienteId)
        {
            return BadRequest();
        }

        _context.Entry(cliente).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClienteExists(id))
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
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ClienteExists(int id)
    {
        return _context.Clientes.Any(e => e.ClienteId == id);
    }
}
