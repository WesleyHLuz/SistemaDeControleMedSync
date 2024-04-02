using SistemaDeControleMedSync.API.Exceptions;

namespace SistemaDeControleMedSync.API.ValueObject
{
    public class Cnpj
    {
        public Cnpj() { }
        public string Numero { get; }

        public Cnpj(string numero)
        {
            if (!Validar(numero)) throw new DocumentoException("Número de documento inválido! Verifique e digite novamente");

            Numero = numero;
        }

        private bool Validar(string valor)
        {
            // Remove caracteres não numéricos do CNPJ
            string cnpjLimpo = new string(valor.Where(char.IsDigit).ToArray());

            // Verifica se o CNPJ tem 14 dígitos
            if (cnpjLimpo.Length != 14)
                return false;

            // Calcula o primeiro dígito verificador
            int[] multiplicadoresPrimeiroDigito = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(cnpjLimpo[i].ToString()) * multiplicadoresPrimeiroDigito[i];
            }
            int resto = soma % 11;
            int primeiroDigitoVerificador = resto < 2 ? 0 : 11 - resto;

            // Calcula o segundo dígito verificador
            int[] multiplicadoresSegundoDigito = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(cnpjLimpo[i].ToString()) * multiplicadoresSegundoDigito[i];
            }
            resto = soma % 11;
            int segundoDigitoVerificador = resto < 2 ? 0 : 11 - resto;

            // Verifica se os dígitos verificadores calculados são iguais aos dígitos verificadores fornecidos
            return int.Parse(cnpjLimpo[12].ToString()) == primeiroDigitoVerificador &&
                   int.Parse(cnpjLimpo[13].ToString()) == segundoDigitoVerificador;
        }
    }
}
