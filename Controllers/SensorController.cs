using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mottu.Data;
using Mottu.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mottu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SensorController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpPost]
        public async Task<ActionResult> CreateSensor(Sensor_IoT sensor)
        {
            _context.Sensores.Add(sensor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSensorById), new { id = sensor.Id_Sensor }, sensor);
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sensor_IoT>>> GetAllSensors()
        {
            var sensores = await _context.Sensores.ToListAsync();
            return Ok(sensores);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor_IoT>> GetSensorById(int id)
        {
            var sensor = await _context.Sensores.FindAsync(id);
            if (sensor == null)
                return NotFound($"Sensor com ID {id} não encontrado.");

            return Ok(sensor);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSensor(int id, Sensor_IoT sensor)
        {
            if (id != sensor.Id_Sensor)
                return BadRequest("ID informado não bate com o corpo da requisição.");

            _context.Entry(sensor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Sensores.Any(s => s.Id_Sensor == id))
                    return NotFound($"Sensor com ID {id} não encontrado.");
                else
                    throw;
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSensor(int id)
        {
            var sensor = await _context.Sensores.FindAsync(id);
            if (sensor == null)
                return NotFound($"Sensor com ID {id} não encontrado.");

            _context.Sensores.Remove(sensor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}