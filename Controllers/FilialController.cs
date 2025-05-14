using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mottu.Data;
using Mottu.Models;

namespace Mottu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilialController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FilialController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filial>>> GetAll()
        {
            return Ok(await _context.Filiais.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Filial>> GetById(int id)
        {
            var filial = await _context.Filiais.FindAsync(id);
            if (filial == null) return NotFound();
            return Ok(filial);
        }

        [HttpGet("cidade")]
        public async Task<ActionResult<IEnumerable<Filial>>> GetByCidade([FromQuery] string cidade)
        {
            var filiais = await _context.Filiais.Where(f => f.Cidade == cidade).ToListAsync();
            return Ok(filiais);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Filial filial)
        {
            _context.Filiais.Add(filial);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = filial.Id_Filial }, filial);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Filial filial)
        {
            if (id != filial.Id_Filial) return BadRequest();
            _context.Entry(filial).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filial = await _context.Filiais.FindAsync(id);
            if (filial == null) return NotFound();

            _context.Filiais.Remove(filial);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}