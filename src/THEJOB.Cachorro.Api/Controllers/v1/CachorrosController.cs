using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THEJOB.Cachorro.Repository;

namespace THEJOB.Cachorro.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CachorrosController : ControllerBase
    {
        public readonly CachorroContext _context;

        public CachorrosController(CachorroContext cachorroContext)
        {
            _context = cachorroContext;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Domain.Cachorro>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarAsync()
        {
            var items = await _context.Cachorros.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync(Guid id)
        {
            var cachorro = await _context.Cachorros.FindAsync(id);
            if (cachorro == null)
            {
                return NotFound();
            }

            return Ok(cachorro);
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Domain.Cachorro), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarCachorroAsync(
            [FromBody] THEJOB.Cachorro.Domain.Cachorro cachorro)
        {
            _context.Add(cachorro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("ObterPorId", new { id = cachorro.Id }, cachorro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCachorroAsync(
            Guid id,
            THEJOB.Cachorro.Domain.Cachorro cachorro)
        {
            if (id != cachorro.Id)
            {
                return BadRequest();
            }

            _context.Entry(cachorro).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ExcluirCachorroAsync(Guid id)
        {
            var cachorro = await _context.Cachorros.FindAsync(id);

            if (cachorro == null)
                return NotFound();

            _context.Remove(cachorro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}