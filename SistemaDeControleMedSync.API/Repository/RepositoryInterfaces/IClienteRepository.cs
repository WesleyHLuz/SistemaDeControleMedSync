using Microsoft.AspNetCore.Mvc;
using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IClienteRepository: IDeletaDados, IValidaDados
    {
        Task<Cliente> Get(int id);

        Task<ICollection<Cliente>> List();

        Task<bool> Save(Cliente dados);

        Task<bool> Update(int id, Cliente novosDados);

    }
}
