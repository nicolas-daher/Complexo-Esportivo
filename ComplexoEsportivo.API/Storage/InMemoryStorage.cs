namespace ComplexoEsportivo.Storage;

using ComplexoEsportivo.Models;

public class InMemoryStorage
{
    public List<Quadra> Quadras { get; } = new();
    public List<Reserva> Reservas { get; } = new();
    private int _quadraIdCounter = 1;
    private int _reservaIdCounter = 1;

    public int NextQuadraId() => _quadraIdCounter++;
    public int NextReservaId() => _reservaIdCounter++;
}