using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{

    public interface IEspecialidadeRepository: IDeletaDados
    {
        Task<Especialidade> Get(int id);
        Task<List<Especialidade>> List();

        Task<bool> Update(int id, Especialidade especialidade);

        Task<bool> Save(Especialidade model);

    }
}
