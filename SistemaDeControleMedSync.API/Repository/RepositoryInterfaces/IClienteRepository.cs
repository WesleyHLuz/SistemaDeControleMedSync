using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IClienteRepository: IDeletaDados
    {
        Task<Cliente> Get(int id);

        Task<ICollection<Cliente>> List();

        Task<ValidationResult> Save(Cliente dados);

        Task<ValidationResult> Update(int id, Cliente novosDados);

    }
}
