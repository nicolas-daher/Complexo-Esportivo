using ComplexoEsportivo.Services;
using ComplexoEsportivo.Storage;

public class ReservaServiceTests
{
    private (QuadraService quadraService, ReservaService reservaService) CriarServicos()
    {
        var storage = new InMemoryStorage();
        return (new QuadraService(storage), new ReservaService(storage));
    }

    [Fact]
    public void ReservarHorario_DeveFuncionar_QuandoHorarioLivre()
    {
        var (quadraService, reservaService) = CriarServicos();
        quadraService.CadastrarQuadra("Quadra 1", "Futsal");

        var (sucesso, _, reserva) = reservaService.ReservarHorario(
            1, "João", DateTime.Today.AddHours(10), DateTime.Today.AddHours(11));

        Assert.True(sucesso);
        Assert.NotNull(reserva);
    }

    [Fact]
    public void ReservarHorario_DeveRetornarErro_QuandoHorarioConflita()
    {
        var (quadraService, reservaService) = CriarServicos();
        quadraService.CadastrarQuadra("Quadra 1", "Futsal");

        reservaService.ReservarHorario(
            1, "João", DateTime.Today.AddHours(10), DateTime.Today.AddHours(12));

        var (sucesso, mensagem, _) = reservaService.ReservarHorario(
            1, "Maria", DateTime.Today.AddHours(11), DateTime.Today.AddHours(13));

        Assert.False(sucesso);
        Assert.Contains("reservado", mensagem);
    }

    [Fact]
    public void ReservarHorario_DeveRetornarErro_QuandoQuadraNaoExiste()
    {
        var (_, reservaService) = CriarServicos();

        var (sucesso, mensagem, _) = reservaService.ReservarHorario(
            99, "João", DateTime.Today.AddHours(10), DateTime.Today.AddHours(11));

        Assert.False(sucesso);
        Assert.Contains("não encontrada", mensagem);
    }
}