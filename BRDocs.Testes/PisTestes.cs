using Xunit;

namespace BRDocs.Testes;

public class PisTestes
{
    [Fact]
    public void PisValido()
    {
        string pisValido = "512.54648.26-0";
        bool resultado = Pis.Validar(pisValido);
        Assert.True(resultado);
    }
    
    [Fact]
    public void PisInvalido_TamanhoMaximo()
    {
        string pisValido = "512.54648.26-03";
        bool resultado = Pis.Validar(pisValido);
        Assert.False(resultado);
    }
    
    [Fact]
    public void PisInvalido_TamanhoMinimo()
    {
        string pisValido = "512.54648.26";
        bool resultado = Pis.Validar(pisValido);
        Assert.False(resultado);
    }
    
    [Fact]
    public void PisInvalido_NaoHaNumeros()
    {
        string pisValido = "_+@#$%¨&*()";
        bool resultado = Pis.Validar(pisValido);
        Assert.False(resultado);
    }
    
    [Fact]
    public void PisInvalido_NaoHaNumeros_E_TamanhoInvalido()
    {
        string pisValido = "_+@#$%¨&ASD";
        bool resultado = Pis.Validar(pisValido);
        Assert.False(resultado);
    }
    
    [Fact]
    public void PisInvalido_DigitoVerificadorInvalido()
    {
        string pisValido = "512.54648.26-9";
        bool resultado = Pis.Validar(pisValido);
        Assert.False(resultado);
    }
}
