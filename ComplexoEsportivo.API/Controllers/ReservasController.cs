namespace ComplexoEsportivo.Controllers;

using ComplexoEsportivo.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ReservasController : ControllerBase
{
    private readonly ReservaService _reservaService;

    public ReservasController(ReservaService reservaService)
    {
        _reservaService = reservaService;
    }

    [HttpPost]
    public IActionResult ReservarHorario([FromBody] ReservarHorarioRequest request)
    {
        var (sucesso, mensagem, reserva) = _reservaService.ReservarHorario(
            request.QuadraId, request.NomeCliente, request.Inicio, request.Fim);

        if (!sucesso)
            return BadRequest(mensagem);

        return Created($"/api/reservas/{reserva!.Id}", reserva);
    }
}

public record ReservarHorarioRequest(
    int QuadraId,
    string NomeCliente,
    DateTime Inicio,
    DateTime Fim);