namespace ComplexoEsportivo.Controllers;

using ComplexoEsportivo.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ConsultasController : ControllerBase
{
    private readonly QuadraService _quadraService;
    private readonly ReservaService _reservaService;

    public ConsultasController(QuadraService quadraService, ReservaService reservaService)
    {
        _quadraService = quadraService;
        _reservaService = reservaService;
    }

    [HttpGet("quadras")]
    public IActionResult ListarQuadras() => Ok(_quadraService.ListarQuadras());

    [HttpGet("reservas")]
    public IActionResult ListarReservas() => Ok(_reservaService.ListarReservas());
}