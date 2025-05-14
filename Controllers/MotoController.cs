using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mottu.Data;
using Mottu.Models;

namespace Mottu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MotoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moto>>> GetAll()
        {
            var motos = await _context.Motos
                .Include(m => m.Sensor)
                .Include(m => m.Filial)
                .ToListAsync();
            return Ok(motos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Moto>> GetById(int id)
        {
            var moto = await _context.Motos
                .Include(m => m.Sensor)
                .Include(m => m.Filial)
                .FirstOrDefaultAsync(m => m.Id_Moto == id);

            if (moto == null) return NotFound();
            return Ok(moto);
        }

        [HttpGet("por-status")]
        public async Task<ActionResult<IEnumerable<Moto>>> GetByStatus([FromQuery] string status)
        {
            var motos = await _context.Motos.Where(m => m.Status_Atual == status).ToListAsync();
            if (!motos.Any()) return NotFound("Nenhuma moto encontrada com esse status.");
            return Ok(motos);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Moto moto)
        {
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = moto.Id_Moto }, moto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Moto moto)
        {
            if (id != moto.Id_Moto) return BadRequest();

            _context.Entry(moto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return NotFound();

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}