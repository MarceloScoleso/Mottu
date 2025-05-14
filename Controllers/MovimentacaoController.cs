using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mottu.Data;
using Mottu.Models;

namespace Mottu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MovimentacaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimentacao>>> GetAll()
        {
            return Ok(await _context.Movimentacoes
                .Include(m => m.Moto)
                .Include(m => m.Vaga)
                .Include(m => m.Operador)
                .ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movimentacao>> GetById(int id)
        {
            var mov = await _context.Movimentacoes.FindAsync(id);
            if (mov == null) return NotFound();
            return Ok(mov);
        }

        [HttpGet("por-operador/{idOperador}")]
        public async Task<ActionResult<IEnumerable<Movimentacao>>> GetByOperador(int idOperador)
        {
            var movs = await _context.Movimentacoes.Where(m => m.Id_Operador == idOperador).ToListAsync();
            return Ok(movs);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Movimentacao mov)
        {
            _context.Movimentacoes.Add(mov);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = mov.Id_Mov }, mov);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Movimentacao mov)
        {
            if (id != mov.Id_Mov) return BadRequest();
            _context.Entry(mov).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var mov = await _context.Movimentacoes.FindAsync(id);
            if (mov == null) return NotFound();

            _context.Movimentacoes.Remove(mov);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}