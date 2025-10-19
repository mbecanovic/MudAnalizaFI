using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudAnalizaFI.Context;
using Shared;

namespace MudAnalizaFI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionaListaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OperacionaListaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/OperacionaLista
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperacionaLista>>> GetOperacionaLista()
        {
            return await _context.OperacionaLista.ToListAsync();
        }

        // GET: api/OperacionaLista/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperacionaLista>> GetOperacionaLista(int id)
        {
            var operacionaLista = await _context.OperacionaLista.FindAsync(id);

            if (operacionaLista == null)
            {
                return NotFound();
            }

            return operacionaLista;
        }

        // PUT: api/OperacionaLista/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperacionaLista(int id, OperacionaLista operacionaLista)
        {
            if (id != operacionaLista.Id)
            {
                return BadRequest();
            }

            _context.Entry(operacionaLista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperacionaListaExists(id))
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

        // POST: api/OperacionaLista
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OperacionaLista>> PostOperacionaLista(OperacionaLista operacionaLista)
        {
            _context.OperacionaLista.Add(operacionaLista);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperacionaLista", new { id = operacionaLista.Id }, operacionaLista);
        }

        // DELETE: api/OperacionaLista/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperacionaLista(int id)
        {
            var operacionaLista = await _context.OperacionaLista.FindAsync(id);
            if (operacionaLista == null)
            {
                return NotFound();
            }

            _context.OperacionaLista.Remove(operacionaLista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperacionaListaExists(int id)
        {
            return _context.OperacionaLista.Any(e => e.Id == id);
        }
    }
}
