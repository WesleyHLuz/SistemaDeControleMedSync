using SistemaDeControleMedSync.API.Entities;

namespace SistemaDeControleMedSync.API.Model
{
    public class ValidaCliente
    {
        public bool Validar(Cliente cliente)
        {
            return cliente.Email.Validar() && cliente.Cpf.Validar();
        }
    }
}
