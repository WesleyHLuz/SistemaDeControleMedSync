using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IMedicoRepository: IDeletaDados, IValidaDados
    {
        Task<Medico> Get(int id);

        Task<ICollection<Medico>> List();

        Task<bool> Save(Medico dados);

        Task<bool> Update(int id, Medico novosDados);

    }
}
