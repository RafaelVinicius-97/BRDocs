﻿using System.Text.RegularExpressions;

namespace BRDocs.Lib;

public static class CPF
{
    private static readonly int _tamanhoDocumento = 11;
    private static readonly int[] _multiplicadoresSemDigitoVerificador = [10, 9, 8, 7, 6, 5, 4, 3, 2];
    private static readonly int[] _multiplicadoresComUmDigitoVerificador = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

    public static bool Validar(string documento)
    {
        documento = RemoverCaracteresEspeciais(documento);

        if (!DigitosEstaoValidos(documento))
            return false;

        return DigitosVerificadoresValidos(documento);
    }

    private static string RemoverCaracteresEspeciais(string documento) =>
        documento.Trim().Replace(".", "").Replace("-", "");

    private static bool DigitosEstaoValidos(string documento)
    {
        if (documento.All(char.IsDigit) is false)
            return false;

        return documento.Length == _tamanhoDocumento;
    }

    private static bool DigitosVerificadoresValidos(string documento)
    {
        var digitoVerificadorCalculado = CalcularDigitoVerificador(documento, tamanhoDocumento: 9, _multiplicadoresSemDigitoVerificador);

        if (documento[9] != digitoVerificadorCalculado.ToString()[0])
            return false;

        digitoVerificadorCalculado = CalcularDigitoVerificador(documento, tamanhoDocumento: 10, _multiplicadoresComUmDigitoVerificador);

        if (documento[10] != digitoVerificadorCalculado.ToString()[0])
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