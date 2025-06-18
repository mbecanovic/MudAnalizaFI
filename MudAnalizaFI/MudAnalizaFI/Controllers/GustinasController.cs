using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudAnalizaFI.Context;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudAnalizaFI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GustinasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GustinasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gustina>>> GetAll()
        {
            return await _context.Gustine.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gustina>> Get(int id)
        {
            var gustina = await _context.Gustine.FindAsync(id);

            if (gustina == null)
                return NotFound();

            return gustina;
        }

        [HttpPost]
        public async Task<ActionResult<Gustina>> Create(Gustina gustina)
        {
            _context.Gustine.Add(gustina);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = gustina.Id }, gustina);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Gustina gustina)
        {
            if (id != gustina.Id)
                return BadRequest();

            _context.Entry(gustina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Gustine.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var gustina = await _context.Gustine.FindAsync(id);
            if (gustina == null)
                return NotFound();

            _context.Gustine.Remove(gustina);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
