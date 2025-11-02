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
        public async Task<ActionResult<OperacionaLista>> GetLista(int id)
        {
            var lista = await _context.OperacionaLista
                .Include(l => l.TextFieldItems)
                    .ThenInclude(t => t.Element)         // <-- Include glavnog elementa
                .Include(l => l.TextFieldItems)
                    .ThenInclude(t => t.PodElementi)    // <-- Include podelementa
                .FirstOrDefaultAsync(l => l.Id == id);

            if (lista == null) return NotFound();

            return lista;
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
            // 🔹 1. Proveri da li već postoji lista sa istom SifraPaketa
            var postojecaLista = await _context.OperacionaLista
                .Include(o => o.TextFieldItems)
                .FirstOrDefaultAsync(o => o.SifraPaketa == operacionaLista.SifraPaketa);

            if (postojecaLista != null)
            {
                // 🔹 2. Ažuriraj samo izmene na postojećoj listi
                postojecaLista.DuzinaPaketa = operacionaLista.DuzinaPaketa;
                postojecaLista.BrzinaLinijeUMinuti = operacionaLista.BrzinaLinijeUMinuti;
                postojecaLista.DatumKreiranja = DateTime.UtcNow;

                // 🔹 3. Obrisi stare stavke i dodaj nove (ako želiš full refresh)
                _context.TextFieldItems.RemoveRange(postojecaLista.TextFieldItems ?? new List<TextFieldItem>());
                await _context.SaveChangesAsync(); // da bi se obrisale veze

                postojecaLista.TextFieldItems = operacionaLista.TextFieldItems;

                // 🔹 4. Poveži FK-ove
                if (postojecaLista.TextFieldItems != null)
                {
                    foreach (var item in postojecaLista.TextFieldItems)
                    {
                        item.OperacionaListaId = postojecaLista.Id;
                        item.OperacionaLista = null; // da izbegneš EF konflikt
                    }
                }

                _context.OperacionaLista.Update(postojecaLista);
                await _context.SaveChangesAsync();

                return Ok(postojecaLista);
            }

            // 🔹 5. Ako ne postoji — dodaj novu listu
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
