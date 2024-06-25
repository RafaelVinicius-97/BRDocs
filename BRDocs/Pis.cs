using System.Text.RegularExpressions;

namespace BRDocs;

public class Pis
{
    private static readonly int[] Multiplicadores = [3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
    private static readonly int TamanhoDocumento = 11;
    
    public static bool Validar(string documento)
    {
        RemoverCaracteresEspeciais(ref documento);
        
        int tamanhoDocumento = documento.Length;
        if (DigitosEstaoValidos(ref documento) is false)
            return false;
        
        char digitoVerificador = documento
            .Substring(tamanhoDocumento - 1)
            .ToCharArray()
            .First();

        var digitoVerificadorCalculado = CalcularDigitoVerificador(documento, tamanhoDocumento - 1);
        
        return int.Parse(digitoVerificador.ToString()) == digitoVerificadorCalculado;
    }

    private static bool DigitosEstaoValidos(ref string documento)
    {
        if (ValidarTodosOsDigitos(ref documento) is false)
            return false;

        if (TamanhoValido(documento.Length) is false)
            return false;

        return true;
    }
    
    private static bool ValidarTodosOsDigitos(ref string documento) =>
        Regex.IsMatch(documento, "^[0-9]{3}.?[0-9]{5}.?[0-9]{2}-?[0-9]{1}");
    
    private static void RemoverCaracteresEspeciais(ref string documento) =>
        documento = documento
            .Trim()
            .Replace(".", "")
            .Replace("-", "");
    
    private static bool TamanhoValido(int tamanho) => 
        tamanho == TamanhoDocumento;
    
    private static int CalcularDigitoVerificador(string documento, int tamanhoDocumento)
    {
        var soma = 0;
        for (var index = 0; index < tamanhoDocumento; index++)
        {
            soma += int.Parse(documento[index].ToString()) * Multiplicadores[index];
        }

        var resto = soma % 11;

        return resto < 2 ? 0 : 11 - resto;
    }
}