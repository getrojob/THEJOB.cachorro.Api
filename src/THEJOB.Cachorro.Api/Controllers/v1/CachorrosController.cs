using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THEJOB.Cachorro.Domain;
using THEJOB.Cachorro.Repository;

namespace DEPLOY.Cachorro.Api.Controllers.v1
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
        [ProducesResponseType(typeof(IEnumerable<THEJOB.Cachorro.Domain.Cachorro>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Listar()
        {
            var items = await _context.Cachorros.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var cachorro = _context.Cachorros.FindAsync(id);

            if (cachorro == null)
                return NotFound();

            return Ok(cachorro);
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(THEJOB.Cachorro.Domain.Cachorro), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarCachorro(
            [FromBody] THEJOB.Cachorro.Domain.Cachorro cachorro)
        {
            _context.Add(cachorro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("ObterPorId", new { id = cachorro.Id }, cachorro);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ExcluirCachorro(int id)
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