namespace ComplexoEsportivo.Services;

using ComplexoEsportivo.Models;
using ComplexoEsportivo.Storage;

public class QuadraService
{
    private readonly InMemoryStorage _storage;

    public QuadraService(InMemoryStorage storage)
    {
        _storage = storage;
    }

    public Quadra CadastrarQuadra(string nome, string tipo)
    {
        var quadra = new Quadra
        {
            Id = _storage.NextQuadraId(),
            Nome = nome,
            Tipo = tipo
        };
        _storage.Quadras.Add(quadra);
        return quadra;
    }

    public List<Quadra> ListarQuadras() => _storage.Quadras;
}