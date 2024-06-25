using Xunit;

namespace BRDocs.Testes;

public class CnpjTestes
{
    [Fact]
    public void CnpjValido()
    {
        var cnpjValido = "18.341.634/0001-73";
        var resultado = Cnpj.Validar(cnpjValido);
        Assert.True(resultado);
    }

    [Fact]
    public void CnpjInvalido_TamanhoMaximo()
    {
        var cnpjInvalido = "18.341.634/0001-730";
        var resultado = Cnpj.Validar(cnpjInvalido);
        Assert.False(resultado);
    }
    
    [Fact]
    public void CnpjInvalido_TamanhoMinimo()
    {
        var cnpjInvalido = "18.341.634/0001-7";
        var resultado = Cnpj.Validar(cnpjInvalido);
        Assert.False(resultado);
    }

    [Fact]
    public void CnpjInvalido_NaoHaNumeros()
    {
        var cnpjInvalido = "";
        var resultado = Cnpj.Validar(cnpjInvalido);
        Assert.False(resultado);   
    }

    [Fact]
    public void CnpjInvalido_NaoHaNumeros_E_TamanhoInvalido()
    {
        var cnpjInvalido = "";
        var resultado = Cnpj.Validar(cnpjInvalido);
        Assert.False(resultado);
    }
}