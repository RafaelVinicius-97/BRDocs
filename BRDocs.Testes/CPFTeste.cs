using BRDocs.Lib;

namespace BRDocs.Testes;

public class CPFTestes
{
    [Fact]
    public void CpfValido()
    {
        string cpfValido = "847.678.820-79";
        bool resultado = CPF.Validar(cpfValido);
        Assert.True(resultado);
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
        string cpfInvalido = "_+@#$%¨&*()ASD";
        bool resultado = CPF.Validar(cpfInvalido);
        Assert.False(resultado);
    }
}