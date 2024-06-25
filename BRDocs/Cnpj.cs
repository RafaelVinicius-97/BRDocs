using System.Text.RegularExpressions;

namespace BRDocs;

public class Cnpj
{
    private static readonly int TamanhoDocumento = 14;
        
    public static bool Validar(string documento)
    {
        RemoverCaracteresEspeciais(ref documento);

        if (DigitosEstaoValidos(ref documento))
            return false;
        
        return false;
    }

    private static bool DigitosEstaoValidos(ref string documento)
    {
        if (TamanhoValido(documento.Length) is false)
            return false;

        if (ValidarTodosOsDigitos(ref documento) is false)
            return false;
        
        return true;
    }

    private static void RemoverCaracteresEspeciais(ref string documento) =>
    documento = documento
        .Trim()
        .Replace(".","")
        .Replace("-","")
        .Replace("/","");
    
    private static bool TamanhoValido(int tamanho) =>
        tamanho == TamanhoDocumento;

    private static bool ValidarTodosOsDigitos(ref string documento) =>
        Regex.IsMatch(documento, "^[0-9]{3}.?[0-9]{3}.?[0-9]{3}-?[0-9]{2}");
}