using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsulinResistanceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktController : ControllerBase
    {
        private readonly IProduktService _produktService;

        public ProduktController(IProduktService produktService)
        {
            _produktService = produktService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Produkt>>>> GetProdukt()
        {
            var result = await _produktService.GetProduktAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{produktId}")]
        public async Task<ActionResult<ServiceResponse<Produkt>>> GetProdukt(int produktId)
        {
            var result = await _produktService.GetProduktAsync(produktId);
            return Ok(result);
        }

        [HttpGet]
        [Route("kategoria/{kategoriaUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Produkt>>>> GetProduktByCategory(string kategoriaUrl)
        {
            var result = await _produktService.GetProduktByCategory(kategoriaUrl);
            return Ok(result);
        }

        [HttpGet]
        [Route("szukaj/{searchText}/{requestedPage}")]
        public async Task<ActionResult<ServiceResponse<ProductSearchResultDTO>>> SearchProdukt(string searchText, int requestedPage = 1)
        {
            var result = await _produktService.SearchProdukt(searchText, requestedPage);
            return Ok(result);
        }

        [HttpGet]
        [Route("szukajsugestie/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Produkt>>>> GetProduktSearchSuggestions(string searchText)
        {
            var result = await _produktService.GetSearchSuggestions(searchText);
            return Ok(result);
        }

    }
}
