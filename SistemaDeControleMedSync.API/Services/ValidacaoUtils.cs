using SistemaDeControleMedSync.API.ValueObject;
using System.Text.RegularExpressions;

namespace SistemaDeControleMedSync.API.Services
{
    public class ValidacaoUtils 
    {
        public ValidationResult ValidaCpf(string cpf)
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
    
        public ValidationResult ValidaEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return new ValidationResult { IsValid = false, ErrorMessage = "O CPF deve conter 11 dígitos" };

            // Padrão de validação de e-mail utilizando uma expressão regular
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Verifica se o endereço de e-mail corresponde ao padrão
            if(!Regex.IsMatch(valor, pattern)) return new ValidationResult { IsValid = false, ErrorMessage = "O email é inválido!"};

            return new ValidationResult { IsValid = true };
       }

        public ValidationResult ValidaCnpj(string cnpj)
        {
            // Remove caracteres não numéricos do CNPJ
            string cnpjLimpo = new string(valor.Where(char.IsDigit).ToArray());

            // Verifica se o CNPJ tem 14 dígitos
            if (cnpjLimpo.Length != 14)
                return new ValidationResult { IsValid = false, ErrorMessage = "O CNPJ deve conter 14 dígitos." };

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
            if (int.Parse(cnpjLimpo[12].ToString()) != primeiroDigitoVerificador ||
                int.Parse(cnpjLimpo[13].ToString()) != segundoDigitoVerificador)
            {
                return new ValidationResult { IsValid = false, ErrorMessage = "O CNPJ é inválido." };
            }

            return new ValidationResult { IsValid = true };
        }

        public ValidationResult ValidarTelefone(string telefone)
        {
            ValidationResult validationResult = new ValidationResult();

            // Remover caracteres não numéricos do telefone
            string telefoneLimpo = new string(telefone.Where(char.IsDigit).ToArray());

            // Verificar se o telefone tem o formato correto (exemplo: (00) 0000-0000)
            if (telefoneLimpo.Length != 10 && telefoneLimpo.Length != 11)
            {
                validationResult.IsValid = false;
                validationResult.ErrorMessage = "O telefone deve ter 10 ou 11 dígitos.";
                return validationResult;
            }

            // Se chegou até aqui, o telefone é válido
            validationResult.IsValid = true;
            return validationResult;
        }


    }

}
