namespace ComplexoEsportivo.Services;

using ComplexoEsportivo.Models;
using ComplexoEsportivo.Storage;

public class ReservaService
{
    private readonly InMemoryStorage _storage;

    public ReservaService(InMemoryStorage storage)
    {
        _storage = storage;
    }

    public (bool sucesso, string mensagem, Reserva? reserva) ReservarHorario(
        int quadraId, string nomeCliente, DateTime inicio, DateTime fim)
    {
        var quadraExiste = _storage.Quadras.Any(q => q.Id == quadraId);
        if (!quadraExiste)
            return (false, "Quadra não encontrada.", null);

        bool conflito = _storage.Reservas.Any(r =>
            r.QuadraId == quadraId &&
            r.DataHoraInicio < fim &&
            r.DataHoraFim > inicio);

        if (conflito)
            return (false, "Horário já reservado para esta quadra neste mesmo período.", null);

        var reserva = new Reserva
        {
            Id = _storage.NextReservaId(),
            QuadraId = quadraId,
            NomeCliente = nomeCliente,
            DataHoraInicio = inicio,
            DataHoraFim = fim
        };
        _storage.Reservas.Add(reserva);
        return (true, "Reserva criada com sucesso.", reserva);
    }

    public List<Reserva> ListarReservas() => _storage.Reservas;
}