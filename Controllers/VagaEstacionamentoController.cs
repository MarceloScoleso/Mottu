using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mottu.Data;
using Mottu.Models;

namespace Mottu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VagaEstacionamentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VagaEstacionamentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaga_Estacionamento>>> GetAll()
        {
            return Ok(await _context.VagasEstacionamento
                                    .Include(v => v.Status) 
                                    .Include(v => v.Filial_Referencia)  
                                    .ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vaga_Estacionamento>> GetById(int id)
        {
            var vaga = await _context.VagasEstacionamento
                                    .Include(v => v.Status)
                                    .Include(v => v.Filial_Referencia)
                                    .FirstOrDefaultAsync(v => v.Id_Vaga == id);

            if (vaga == null) return NotFound();
            return Ok(vaga);
        }

        [HttpGet("status")]
        public async Task<ActionResult<IEnumerable<Vaga_Estacionamento>>> GetByStatus([FromQuery] string status)
        {
            var vagas = await _context.VagasEstacionamento
                                    .Include(v => v.Status)  // Inclui o Status relacionado
                                    .Where(v => v.Status.Descricao_Status == status) // Agora filtrando pelo Descricao_Status
                                    .ToListAsync();

            return Ok(vagas);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Vaga_Estacionamento vaga)
        {
            _context.VagasEstacionamento.Add(vaga);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = vaga.Id_Vaga }, vaga);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Vaga_Estacionamento vaga)
        {
            if (id != vaga.Id_Vaga) return BadRequest();
            _context.Entry(vaga).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var vaga = await _context.VagasEstacionamento.FindAsync(id);
            if (vaga == null) return NotFound();

            _context.VagasEstacionamento.Remove(vaga);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}