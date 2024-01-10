using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get()
        {
            var items = _context.Cachorros.ToList();
            return Ok(items);
        }

        [HttpPost]
        public IActionResult CadastrarCachorro(
            [FromBody] THEJOB.Cachorro.Domain.Cachorro cachorro)
        {
            _context.Add(cachorro);

            return Ok();
        }
    }
}