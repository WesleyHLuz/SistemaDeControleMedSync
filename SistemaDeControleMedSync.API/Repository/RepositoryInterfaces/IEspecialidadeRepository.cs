using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{

    public interface IEspecialidadeRepository: IDeletaDados
    {
        Task<Especialidade> Get(int id);
        Task<List<Especialidade>> List();

        Task<ValidationResult> Update(int id, Especialidade especialidade);

        Task<ValidationResult> Save(Especialidade model);

    }
}
