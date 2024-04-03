using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IMedicoRepository: IDeletaDados
    {
        Task<Medico> Get(int id);

        Task<ICollection<Medico>> List();

        Task<ValidationResult> Save(Medico dados);

        Task<ValidationResult> Update(int id, Medico novosDados);

    }
}
