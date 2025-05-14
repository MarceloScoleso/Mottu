using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mottu.Data;
using Mottu.Models;

namespace Mottu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperadorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OperadorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operador>>> GetAll()
        {
            return Ok(await _context.Operadores.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Operador>> GetById(int id)
        {
            var op = await _context.Operadores.FindAsync(id);
            if (op == null) return NotFound();
            return Ok(op);
        }

        [HttpGet("login")]
        public async Task<ActionResult<Operador>> GetByLogin([FromQuery] string login)
        {
            var op = await _context.Operadores.FirstOrDefaultAsync(o => o.Login == login);
            if (op == null) return NotFound();
            return Ok(op);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Operador op)
        {
            _context.Operadores.Add(op);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = op.Id_Operador }, op);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Operador op)
        {
            if (id != op.Id_Operador) return BadRequest();
            _context.Entry(op).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var op = await _context.Operadores.FindAsync(id);
            if (op == null) return NotFound();

            _context.Operadores.Remove(op);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}