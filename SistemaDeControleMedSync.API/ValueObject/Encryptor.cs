using BCrypt.Net;
namespace SistemaDeControleMedSync.API.ValueObject
{
    public static class Encryptor
    {
        public static string EncryptPassword(string password)
        {
            // Gera um hash de senha com salt usando BCrypt
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            // Verifica se a senha inserida corresponde à senha hash usando BCrypt
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}
