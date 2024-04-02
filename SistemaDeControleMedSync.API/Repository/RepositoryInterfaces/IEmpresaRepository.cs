using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IEmpresaRepository: IDeletaDados, IValidaDados
    {
        Task<Empresa> Get(int id);

        Task<ICollection<Empresa>> List();

        Task<bool> Save(Empresa dados);

        Task<bool> Update(int id, Empresa novosDados);

    }
}
