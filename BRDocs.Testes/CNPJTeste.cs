using BRDocs.Lib;

namespace BRDocs.Testes;

public class CNPJTeste
{
    [Fact]
    public void CnpjValido()
    {
        var cnpjValido = "18.341.634/0001-73";
        var resultado = CNPJ.Validar(cnpjValido);
        Assert.True(resultado);
    }

    [Fact]
    public void CnpjInvalido_TamanhoMaximo()
    {
        var cnpjInvalido = "18.341.634/0001-730";
        var resultado = CNPJ.Validar(cnpjInvalido);
        Assert.False(resultado);
    }

    [Fact]
    public void CnpjInvalido_TamanhoMinimo()
    {
        var cnpjInvalido = "18.341.634/0001-7";
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
        var cnpjInvalido = "apfdjcMSDK_+{";
        var resultado = CNPJ.Validar(cnpjInvalido);
        Assert.False(resultado);
    }
}
