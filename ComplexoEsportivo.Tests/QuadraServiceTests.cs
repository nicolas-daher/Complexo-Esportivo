using ComplexoEsportivo.Services;
using ComplexoEsportivo.Storage;

public class QuadraServiceTests
{
    [Fact]
    public void CadastrarQuadra_DeveRetornarQuadraComIdGerado()
    {
        var storage = new InMemoryStorage();
        var service = new QuadraService(storage);

        var quadra = service.CadastrarQuadra("Quadra 1", "Futsal");

        Assert.Equal(1, quadra.Id);
        Assert.Equal("Quadra 1", quadra.Nome);
        Assert.Single(storage.Quadras);
    }

    [Fact]
    public void ListarQuadras_DeveRetornarTodasCadastradas()
    {
        var storage = new InMemoryStorage();
        var service = new QuadraService(storage);

        service.CadastrarQuadra("Quadra A", "Tênis");
        service.CadastrarQuadra("Quadra B", "Basquete");

        Assert.Equal(2, service.ListarQuadras().Count);
    }
}