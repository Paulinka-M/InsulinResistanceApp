using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsulinResistanceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriaController : ControllerBase
    {
        private readonly IKategoriaService _kategoriaService;

        public KategoriaController(IKategoriaService kategoriaService)
        {
            _kategoriaService = kategoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Kategoria>>>> GetKategoria()
        {
            var result = await _kategoriaService.GetKategoria();
            return Ok(result);
        }
    }
}
