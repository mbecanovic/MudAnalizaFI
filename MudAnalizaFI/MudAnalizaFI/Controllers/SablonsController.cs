using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudAnalizaFI.Context;
using Shared;
using Shared.Functions;

namespace MudAnalizaFI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SablonsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SablonsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sablons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sablon>>> GetSabloni()
        {
            return await _context.Sabloni.ToListAsync();
        }

        // GET: api/Sablons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sablon>> GetSablon(int id)
        {
            var sablon = await _context.Sabloni.FindAsync(id);

            if (sablon == null)
            {
                return NotFound();
            }

            return sablon;
        }

        // PUT: api/Sablons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSablon(int id, Sablon sablon)
        {
            if (id != sablon.Id)
            {
                return BadRequest();
            }

            _context.Entry(sablon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SablonExists(id))
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

        // POST: api/Sablons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sablon>> PostSablon(Sablon sablon)
        {
            _context.Sabloni.Add(sablon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSablon", new { id = sablon.Id }, sablon);
        }

        // DELETE: api/Sablons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSablon(int id)
        {
            var sablon = await _context.Sabloni.FindAsync(id);
            if (sablon == null)
            {
                return NotFound();
            }

            _context.Sabloni.Remove(sablon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SablonExists(int id)
        {
            return _context.Sabloni.Any(e => e.Id == id);
        }

        [HttpPut("{sablonId}/dodaj-po-sifri")]
        public async Task<IActionResult> DodajElementePoSifri(int sablonId, [FromBody] List<string> sifreElemenata)
        {
            if (sifreElemenata == null || !sifreElemenata.Any())
                return BadRequest("Lista šifara ne sme biti prazna.");

            var sablon = await _context.Sabloni.FindAsync(sablonId);
            if (sablon == null)
                return NotFound($"Šablon sa ID {sablonId} ne postoji.");

            var elementi = await _context.Elementi
                .Where(e => sifreElemenata.Contains(e.Sifra))
                .ToListAsync();

            if (elementi.Count != sifreElemenata.Count)
                return BadRequest("Neki elementi sa datim šiframa nisu pronađeni.");

            foreach (var element in elementi)
            {
                element.SablonId = sablonId;
                element.Kod = string.Join(",", sablon.Kod); // Upisuje kod
                element.Vreme = sablon.Vreme; // Dodeljuje vreme iz sablona 
            }

            await _context.SaveChangesAsync();
            // Replace this line:
            // CheckCode.PrintElement(elementi, sablon);

            // With this line:
            CheckCode.PrintElement(elementi, sablon);
            return Ok("Elementi su uspešno dodeljeni šablonu.");
        }

    
    }
}


