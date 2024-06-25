using System.Text.RegularExpressions;

namespace BRDocs;

public class Cpf
{
    private static readonly int TamanhoDocumento = 11;
    private static readonly int[] MultiplicadoresSemDigitoVerificador = [10, 9, 8, 7, 6, 5, 4, 3, 2];
    private static readonly int[] MultiplicadoresComUmDigitoVerificador = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

    public static bool Validar(string documento)
    {
        RemoverCaracteresEspeciais(ref documento);
        
        if (DigitosEstaoValidos(ref documento) is false)
            return false;

        string documentoSemDigitosVerificadores = documento[..9];
        char[] digitosVerificadores = documento.Substring(9).ToCharArray();

        return DigitosVerificadoresValidos(ref documentoSemDigitosVerificadores, digitosVerificadores);
    }

    private static bool DigitosEstaoValidos(ref string documento)
    {
        if (ValidarTodosOsDigitos(ref documento) is false)
            return false;

        if (TamanhoValido(documento.Length) is false)
            return false;
        
        return true;
    }
    private static void RemoverCaracteresEspeciais(ref string documento) =>
        documento = documento
            .Trim()
            .Replace(".","")
            .Replace("-","");

    private static bool ValidarTodosOsDigitos(ref string documento) =>
        Regex.IsMatch(documento, "^[0-9]{3}.?[0-9]{3}.?[0-9]{3}-?[0-9]{2}");
    
    private static bool TamanhoValido(int tamanho) => 
        tamanho == TamanhoDocumento;

    private static bool DigitosVerificadoresValidos(ref string documento, char[] digitoVerificador)
    {
        var digitoVerificadorCalculado =
            CalcularDigitoVerificador(ref documento, 9, MultiplicadoresSemDigitoVerificador);
        
        if(digitoVerificador[0].ToString() != digitoVerificadorCalculado)
            return false;

        documento = $"{documento}{digitoVerificadorCalculado}";
        
        digitoVerificadorCalculado =
            CalcularDigitoVerificador(ref documento, 10, MultiplicadoresComUmDigitoVerificador);
        
        return digitoVerificador[1].ToString() == digitoVerificadorCalculado;
    }

    private static string CalcularDigitoVerificador(ref string documento, int tamanhoDocumento, int[] multiplicadores)
    {
        var soma = 0;
        for (var index = 0; index < tamanhoDocumento; index++)
        {
            soma += int.Parse(documento[index].ToString()) * multiplicadores[index];
        }

        var resto = soma % 11;
        return (resto < 2 ? 0 : 11 - resto).ToString();
    }
}