using System.Text.RegularExpressions;

namespace BRDocs.Lib;

public class CNPJ
{
    private static readonly int _tamanhoDocumento = 14;
    private static readonly int[] _multiplicadoresSemDigitoVerificador = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
    private static readonly int[] _multiplicadoresComUmDigitoVerificador = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

    public static bool Validar(string documento)
    {
        documento = RemoverCaracteresEspeciais(documento);

        if (DigitosEstaoValidos(documento) is false)
            return false;

        return DigitosVerificadoresValidos(documento);
    }

    private static bool DigitosEstaoValidos(string documento)
    {
        if (documento.All(char.IsDigit) is false)
            return false;

        return documento.Length == _tamanhoDocumento;
    }

    private static string RemoverCaracteresEspeciais(string documento) =>
    documento
        .Trim()
        .Replace(".", "")
        .Replace("-", "")
        .Replace("/", "");

    private static bool DigitosVerificadoresValidos(string documento)
    {
        var digitoVerificadorCalculado = CalcularDigitoVerificador(documento, tamanhoDocumento: 12, _multiplicadoresSemDigitoVerificador);

        if (documento[12] != digitoVerificadorCalculado.ToString()[0])
            return false;

        digitoVerificadorCalculado = CalcularDigitoVerificador(documento, tamanhoDocumento: 13, _multiplicadoresComUmDigitoVerificador);

        if (documento[13] != digitoVerificadorCalculado.ToString()[0])
            return false;

        return true;

        static int CalcularDigitoVerificador(string documento, int tamanhoDocumento, int[] multiplicadores)
        {
            var soma = 0;

            for (var index = 0; index < tamanhoDocumento; index++)
            {
                soma += (documento[index] - '0') * multiplicadores[index];
            }

            var resto = soma % 11;

            return resto < 2 ? 0 : 11 - resto;
        }
    }
}
