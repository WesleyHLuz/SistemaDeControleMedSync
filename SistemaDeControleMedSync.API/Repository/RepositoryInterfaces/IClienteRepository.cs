using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IClienteRepository
    {
        Task<ICliente> BuscaClientePorId(int id);

        Task<List<Cliente>> BuscaTodosClientes();

        Task<Cliente> AdicionaNovoCliente(Cliente cliente);

        Task<bool> AtualizaEmailCliente(int idCliente, string email);

        Task<bool>
    }
}
