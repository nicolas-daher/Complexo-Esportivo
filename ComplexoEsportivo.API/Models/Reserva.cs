namespace ComplexoEsportivo.Models;

public class Reserva
{
    public int Id { get; set; }
    public int QuadraId { get; set; }
    public string NomeCliente { get; set; } = string.Empty;
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
}