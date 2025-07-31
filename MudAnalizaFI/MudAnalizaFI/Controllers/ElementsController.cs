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
    public class ElementsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ElementsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Elements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Element>>> GetElementi()
        {
            var elementi = await _context.Elementi
            .Include(e => e.Gustina)
            .ToListAsync();
            return elementi;
        }

        // GET: api/Elements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Element>> GetElement(int id)
        {
            var element = await _context.Elementi.FindAsync(id);

            if (element == null)
            {
                return NotFound();
            }

            return element;
        }

        // PUT: api/Elements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElement(int id, Element element)
        {
            if (id != element.Id)
            {
                return BadRequest();
            }

            _context.Entry(element).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementExists(id))
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

        // POST: api/Elements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Element>> PostElement(Element element)
        {
            var gustina = await _context.Gustine.FindAsync(element.GustinaId);
            if (gustina == null) return BadRequest("Nepostojeca gustina.");

            var postoji = await _context.Elementi
            .AnyAsync(e => e.Sifra == element.Sifra);

            if (postoji) return BadRequest("Element sa ovom sifrom vec postoji.");

            element.Tezina = Math.Round(element.Duzina * element.Sirina * element.Visina * gustina.Vrednost, 2);


            if (gustina.Opis == "stiropor" || gustina.Opis == "Stiropor" || gustina.Opis == "Lesonit" || element.Tezina < 3) element.BrRadnika = 0.5;
            if(element.Tezina == 8) element.BrRadnika = 2;
            if (element.Tezina >= 3 & element.Tezina < 8) element.BrRadnika = 1;
            if(element.Tezina > 8 || element.Tezina == 0) return BadRequest("Tezina elementa je veca od 8kg, molimo proverite parametre.");
            element.Naziv = gustina.Opis;
            element.Datum = DateTime.Now;
            _context.Elementi.Add(element);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElement", new { id = element.Id }, element);
        }

        // DELETE: api/Elements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElement(int id)
        {
            var element = await _context.Elementi.FindAsync(id);
            if (element == null)
            {
                return NotFound();
            }

            _context.Elementi.Remove(element);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElementExists(int id)
        {
            return _context.Elementi.Any(e => e.Id == id);
        }
    }
}
