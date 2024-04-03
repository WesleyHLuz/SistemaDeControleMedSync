using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;
using System.Text.RegularExpressions;

namespace SistemaDeControleMedSync.API.Services
{
    public class ValidaDadosBasicos
    {
        

        
    
        public ValidationResult ValidaEmail(string valor)
        {
             
            if (string.IsNullOrWhiteSpace(valor))
                return new ValidationResult { IsValid = false, ErrorMessage = "O email não pode ser vazio!" };

            // Padrão de validação de e-mail utilizando uma expressão regular
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Verifica se o endereço de e-mail corresponde ao padrão
            if(!Regex.IsMatch(valor, pattern)) return new ValidationResult { IsValid = false, ErrorMessage = "O email é inválido!"};

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
