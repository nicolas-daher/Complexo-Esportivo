namespace ComplexoEsportivo.Controllers;

using ComplexoEsportivo.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class QuadrasController : ControllerBase
{
    private readonly QuadraService _quadraService;

    public QuadrasController(QuadraService quadraService)
    {
        _quadraService = quadraService;
    }

    [HttpPost]
    public IActionResult CadastrarQuadra([FromBody] CadastrarQuadraRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Nome) || string.IsNullOrWhiteSpace(request.Tipo))
            return BadRequest("Nome e Tipo são obrigatórios.");

        var quadra = _quadraService.CadastrarQuadra(request.Nome, request.Tipo);
        return Created($"/api/quadras/{quadra.Id}", quadra);
    }
}

public record CadastrarQuadraRequest(string Nome, string Tipo);