using Bogus;
using Bogus.Extensions.Brazil;
using BRDocs.Lib;

namespace BRDocs.Testes;

public class CPFTeste
{
    private static readonly Faker _faker = new("pt_BR");

    public static IEnumerable<object[]> Documentos() =>
        [
            [_faker.Person.Cpf()],
            [_faker.Person.Cpf()],
            [_faker.Person.Cpf()],
            [_faker.Person.Cpf()],
            [_faker.Person.Cpf()]
        ];

    [Theory]
    [MemberData(nameof(Documentos))]
    public void CpfValido(string cpf)
    {
        bool resultado = CPF.Validar(cpf);
        Assert.True(resultado, string.Format($"documento: {cpf}"));
    }

    [Fact]
    public void CpfInvalido_PrimeiroDigitoVerificadorIncorreto()
    {
        string cpfInvalido = "847.678.820-19";
        bool resultado = CPF.Validar(cpfInvalido);
        Assert.False(resultado);
    }

    [Fact]
    public void CpfInvalido_SegundoDigitoVerificadorIncorreto()
    {
        string cpfInvalido = "847.678.820-72";
        bool resultado = CPF.Validar(cpfInvalido);
        Assert.False(resultado);
    }

    [Fact]
    public void CpfInvalido_TamanhoMaximo()
    {
        string cpfInvalido = "847.678.820-790";
        bool resultado = CPF.Validar(cpfInvalido);
        Assert.False(resultado);
    }

    [Fact]
    public void CpfInvalido_TamanhoMinimo()
    {
        string cpfInvalido = "847.678.820-7";
        bool resultado = CPF.Validar(cpfInvalido);
        Assert.False(resultado);
    }

    [Fact]
    public void CpfInvalido_NaoHaNumeros()
    {
        string cpfInvalido = "_+@#$%¨&*()";
        bool resultado = CPF.Validar(cpfInvalido);
        Assert.False(resultado);
    }

    [Fact]
    public void CpfInvalido_NaoHaNumeros_E_TamanhoInvalido()
    {
        string cpfInvalido = "_+@sdfHQWvcx#$%d¨&*()A[D";
        bool resultado = CPF.Validar(cpfInvalido);
        Assert.False(resultado);
    }
}