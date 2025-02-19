using Bogus;
using Bogus.Extensions.Brazil;
using BRDocs.Lib;

namespace BRDocs.Testes;

public class CNPJTeste
{
    private static readonly Faker _faker = new("pt_BR");

    public static IEnumerable<object[]> Documentos() =>
        [
            [_faker.Company.Cnpj()],
            [_faker.Company.Cnpj()],
            [_faker.Company.Cnpj()],
            [_faker.Company.Cnpj()],
            [_faker.Company.Cnpj()]
        ];

    [Theory]
    [MemberData(nameof(Documentos))]
    public void CnpjValido(string cnpj)
    {
        var resultado = CNPJ.Validar(cnpj);
        Assert.True(resultado, string.Format($"documento: {cnpj}"));
    }

    [Fact]
    public void CnpjInvalido_TamanhoMaximo()
    {
        var cnpjInvalido = "18.341.634/0001-000";
        var resultado = CNPJ.Validar(cnpjInvalido);
        Assert.False(resultado);
    }

    [Fact]
    public void CnpjInvalido_TamanhoMinimo()
    {
        var cnpjInvalido = "18.341.634/0001-0";
        var resultado = CNPJ.Validar(cnpjInvalido);
        Assert.False(resultado);
    }

    [Fact]
    public void CnpjInvalido_NaoHaNumeros()
    {
        var cnpjInvalido = "apfdjcMSDK_+{";
        var resultado = CNPJ.Validar(cnpjInvalido);
        Assert.False(resultado);
    }

    [Fact]
    public void CnpjInvalido_NaoHaNumeros_E_TamanhoInvalido()
    {
        var cnpjInvalido = "ap$%fdjcMSDK_+{Db,.V{UJjfRW";
        var resultado = CNPJ.Validar(cnpjInvalido);
        Assert.False(resultado);
    }
}
