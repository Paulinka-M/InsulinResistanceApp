using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsulinResistanceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosilekController : ControllerBase
    {
        private readonly IPosilekService _posilekService;

        public PosilekController(IPosilekService posilekService)
        {
            _posilekService = posilekService;
        }
        
        [HttpPost("produkty")]
        public async Task<ActionResult<ServiceResponse<List<ProduktWPosilkuResponse>>>> GetProduktyWPosilku(List<ProduktWPosilku> produktyWPosilku)
        {
            var result = await _posilekService.GetProduktyWPosilku(produktyWPosilku);
            return Ok(result);
        }
    }
}
