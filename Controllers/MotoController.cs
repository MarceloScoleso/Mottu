using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mottu.Data;
using Mottu.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
            // Verifica se sensor informado existe
            if (moto.Id_Sensor.HasValue)
            {
                var sensorExistente = await _context.Sensores.FindAsync(moto.Id_Sensor.Value);
                if (sensorExistente == null)
                {
                    return BadRequest($"Sensor com Id {moto.Id_Sensor.Value} não encontrado.");
                }
                // Não atribuir a propriedade de navegação para evitar erros
                moto.Sensor = null;
            }
            else
            {
                moto.Sensor = null;
            }

            // Verifica se filial informada existe
            if (moto.Id_Filial.HasValue)
            {
                var filialExistente = await _context.Filiais.FindAsync(moto.Id_Filial.Value);
                if (filialExistente == null)
                {
                    return BadRequest($"Filial com Id {moto.Id_Filial.Value} não encontrada.");
                }
                // Não atribuir a propriedade de navegação para evitar erros
                moto.Filial = null;
            }
            else
            {
                moto.Filial = null;
            }

            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = moto.Id_Moto }, moto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Moto moto)
        {
            if (id != moto.Id_Moto) return BadRequest();

            // Evitar problemas com propriedades de navegação no update
            if (moto.Id_Sensor.HasValue)
            {
                var sensorExistente = await _context.Sensores.FindAsync(moto.Id_Sensor.Value);
                if (sensorExistente == null)
                {
                    return BadRequest($"Sensor com Id {moto.Id_Sensor.Value} não encontrado.");
                }
                moto.Sensor = null;
            }
            else
            {
                moto.Sensor = null;
            }

            if (moto.Id_Filial.HasValue)
            {
                var filialExistente = await _context.Filiais.FindAsync(moto.Id_Filial.Value);
                if (filialExistente == null)
                {
                    return BadRequest($"Filial com Id {moto.Id_Filial.Value} não encontrada.");
                }
                moto.Filial = null;
            }
            else
            {
                moto.Filial = null;
            }

            _context.Entry(moto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoExists(id))
                    return NotFound();
                else
                    throw;
            }

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

        private bool MotoExists(int id)
        {
            return _context.Motos.Any(e => e.Id_Moto == id);
        }
    }
}