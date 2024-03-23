using System.Text.RegularExpressions;

namespace SistemaDeControleMedSync.API.ValueObject
{
    public class Email : IEquatable<Email>
    {
        public string Endereco { get; }

        public Email(string endereco)
        {
            if (!Validar(endereco))
            {
                throw new ArgumentException("Endereço de email inválido", nameof(endereco));
            }

            Endereco = endereco;
        }

        public bool Equals(Email other)
        {
            if (other is null)
                return false;

            return Endereco.Equals(other.Endereco, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Email);
        }

        public override int GetHashCode()
        {
            return Endereco.ToLowerInvariant().GetHashCode();
        }

        public override string ToString()
        {
            return Endereco;
        }

        // Método estático para validar o formato do endereço de email
        private static bool Validar(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                return false;

            // Padrão de validação de e-mail utilizando uma expressão regular
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Verifica se o endereço de e-mail corresponde ao padrão
            return Regex.IsMatch(endereco, pattern);
        }
    }
}
