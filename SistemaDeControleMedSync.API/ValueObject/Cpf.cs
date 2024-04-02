using SistemaDeControleMedSync.API.Exceptions;

namespace SistemaDeControleMedSync.API.ValueObject
{
    public class Cpf
    {
        public Cpf() { }
        public string Numero { get; }
        public Cpf(string numero)
        {
            if (!Validar(numero)) throw new DocumentoException("Número de documento inválido! Verifique e digite novamente");

            Numero = numero;
        }

        private bool Validar(string valor)
        {


            if (string.IsNullOrWhiteSpace(valor))
                return false;

            // Remove caracteres não numéricos
            string cpfLimpo = new string(valor.Where(char.IsDigit).ToArray());

            // Verifica se o CPF tem 11 dígitos
            if (cpfLimpo.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais (ex: 111.111.111-11)
            bool todosIguais = cpfLimpo.Distinct().Count() == 1;
            if (todosIguais)
                return false;

            // Calcula os dígitos verificadores
            int[] cpfArray = cpfLimpo.Select(c => int.Parse(c.ToString())).ToArray();
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += cpfArray[i] * (10 - i);

            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += cpfArray[i] * (11 - i);

            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

            // Verifica se os dígitos verificadores estão corretos
            return cpfArray[9] == digitoVerificador1 && cpfArray[10] == digitoVerificador2;

        }
    }
}
