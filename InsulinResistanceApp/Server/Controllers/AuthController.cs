using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InsulinResistanceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("rejestracja")]
        public async Task<ActionResult<ServiceResponse<int>>> Rejestracja(RejestracjaUzytkownika request)
        {
            var response = await _authService.Rejestracja(new Uzytkownik { Email = request.Email }, request.Haslo);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("logowanie")]
        public async Task<ActionResult<ServiceResponse<string>>> Logowanie(LogowanieUzytkownika request)
        {
            var response = await _authService.Logowanie(request.Email, request.Haslo);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost("zmiana-hasla"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ZmianaHasla(ZmianaHasla request)
        {
            var uzytkownikId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _authService.ZmianaHasla(request.StareHaslo, int.Parse(uzytkownikId), request.Haslo);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        [HttpPost("zapomniane-haslo")]
        public async Task<ActionResult<ServiceResponse<bool>>> ZapomnianeHaslo(ZapomnianeHaslo request)
        {
            var response = await _authService.ZapomnianeHaslo(request.Email);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        [HttpPost("nowe-haslo")]
        public async Task<ActionResult<ServiceResponse<string>>> NoweHaslo(NoweHasloRequest request)
        {
            var response = await _authService.NoweHaslo(request.Token, request.Haslo);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}
