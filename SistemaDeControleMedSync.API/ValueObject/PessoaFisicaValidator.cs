using SistemaDeControleMedSync.API.Exceptions;
using SistemaDeControleMedSync.API.Services;

namespace SistemaDeControleMedSync.API.ValueObject
{
    public class PessoaFisicaValidator: ValidaDadosBasicos
    {
        public ValidationResult ValidaCpf(string valor)
        {
            
            if (string.IsNullOrWhiteSpace(valor))
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "O CPF não pode ser vazio!"
                };
            }


            // Remove caracteres não numéricos
            string cpfLimpo = new string(valor.Where(char.IsDigit).ToArray());

            // Verifica se o CPF tem 11 dígitos
            if (cpfLimpo.Length != 11) return new ValidationResult { IsValid = false, ErrorMessage = "O CPF deve conter 11 dígitos" };


            // Verifica se todos os dígitos são iguais (ex: 111.111.111-11)
            bool todosIguais = cpfLimpo.Distinct().Count() == 1;
            if (todosIguais) return new ValidationResult { IsValid = false, ErrorMessage = "Todos os números do CPF são iguais" };


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
            if (cpfArray[9] != digitoVerificador1 && cpfArray[10] != digitoVerificador2) return new ValidationResult { IsValid = false, ErrorMessage = "O CPF é inválido!" };

            return new ValidationResult { IsValid = true };

        }
    }
}
