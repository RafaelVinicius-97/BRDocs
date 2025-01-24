using System.Text.RegularExpressions;

namespace BRDocs.Lib;

public static class Cpf
{
    private static readonly int _tamanhoDocumento = 11;
    private static readonly int[] _multiplicadoresSemDigitoVerificador = [10, 9, 8, 7, 6, 5, 4, 3, 2];
    private static readonly int[] _multiplicadoresComUmDigitoVerificador = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

    public static bool Validar(string documento)
    {
        RemoverCaracteresEspeciais(ref documento);

        if (!DigitosEstaoValidos(ref documento))
            return false;

        return DigitosVerificadoresValidos(documento.ToCharArray());
    }

    private static string RemoverCaracteresEspeciais(ref string documento) =>
        documento = documento.Trim().Replace(".", "").Replace("-", "");

    private static bool DigitosEstaoValidos(ref string documento)
    {
        if (ValidarTodosOsDigitos(documento) is false)
            return false;

        if (TamanhoValido(documento.Length) is false)
            return false;

        return true;

        static bool ValidarTodosOsDigitos(string documento) =>
            Regex.IsMatch(documento, "^[0-9]{3}.?[0-9]{3}.?[0-9]{3}-?[0-9]{2}");

        static bool TamanhoValido(int tamanho) =>
            tamanho == _tamanhoDocumento;
    }

    private static bool DigitosVerificadoresValidos(char[] documento)
    {
        var digitoVerificadorCalculado = CalcularDigitoVerificador(documento, tamanhoDocumento: 9, _multiplicadoresSemDigitoVerificador);

        if (documento[9].ToString() != digitoVerificadorCalculado.ToString())
            return false;

        digitoVerificadorCalculado = CalcularDigitoVerificador(documento, tamanhoDocumento: 10, _multiplicadoresComUmDigitoVerificador);

        if (documento[10].ToString() != digitoVerificadorCalculado.ToString())
            return false;

        return true;

        static int CalcularDigitoVerificador(char[] documento, int tamanhoDocumento, int[] multiplicadores)
        {
            var soma = 0;
            for (var index = 0; index < tamanhoDocumento; index++)
            {
                soma += int.Parse(documento[index].ToString()) * multiplicadores[index];
            }

            var resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }
    }
}