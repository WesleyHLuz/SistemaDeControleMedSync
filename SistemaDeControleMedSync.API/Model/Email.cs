using System.Text.RegularExpressions;

namespace SistemaDeControleMedSync.API.Model
{
    public class Email
    {
        public string Endereco { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(Endereco))
                return false;

            // Padrão de validação de e-mail utilizando uma expressão regular
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Verifica se o endereço de e-mail corresponde ao padrão
            return Regex.IsMatch(Endereco, pattern);
        }
    }
}
