using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;
using MudAnalizaFI.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MudAnalizaFI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaketsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaketsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pakets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paket>>> GetPaketi()
        {
            return await _context.Paketi.ToListAsync();
        }

        // GET: api/Pakets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paket>> GetPaket(int id)
        {
            var paket = await _context.Paketi.FindAsync(id);

            if (paket == null)
            {
                return NotFound();
            }

            return paket;
        }

        // POST: api/Pakets
        [HttpPost]
        public async Task<ActionResult<Paket>> CreatePaket(Paket paket)
        {
            _context.Paketi.Add(paket);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaket), new { id = paket.Id }, paket);
        }

        // PUT: api/Pakets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaket(int id, Paket paket)
        {
            if (id != paket.Id)
            {
                return BadRequest();
            }

            _context.Entry(paket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaketExists(id))
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

        // DELETE: api/Pakets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaket(int id)
        {
            var paket = await _context.Paketi.FindAsync(id);
            if (paket == null)
            {
                return NotFound();
            }

            _context.Paketi.Remove(paket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaketExists(int id)
        {
            return _context.Paketi.Any(e => e.Id == id);
        }
    }
}
