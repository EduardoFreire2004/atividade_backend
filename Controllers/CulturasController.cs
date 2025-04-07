using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atividade_1.Models;

namespace Atividade_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CulturasController : ControllerBase
    {
        private readonly Contexto _context;

        public CulturasController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Culturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cultura>>> GetCulturas()
        {
            return await _context.Culturas.ToListAsync();
        }

        // GET: api/Culturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cultura>> GetCultura(int id)
        {
            var cultura = await _context.Culturas.FindAsync(id);

            if (cultura == null)
            {
                return NotFound();
            }

            return cultura;
        }

        // PUT: api/Culturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCultura(int id, Cultura cultura)
        {
            if (id != cultura.Id)
            {
                return BadRequest();
            }

            _context.Entry(cultura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CulturaExists(id))
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

        // POST: api/Culturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cultura>> PostCultura(Cultura cultura)
        {
            _context.Culturas.Add(cultura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCultura", new { id = cultura.Id }, cultura);
        }

        // DELETE: api/Culturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCultura(int id)
        {
            var cultura = await _context.Culturas.FindAsync(id);
            if (cultura == null)
            {
                return NotFound();
            }

            _context.Culturas.Remove(cultura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CulturaExists(int id)
        {
            return _context.Culturas.Any(e => e.Id == id);
        }
    }
}
