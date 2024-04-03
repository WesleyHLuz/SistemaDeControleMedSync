using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IEmpresaRepository: IDeletaDados
    {
        Task<Empresa> Get(int id);

        Task<ICollection<Empresa>> List();

        Task<ValidationResult> Save(Empresa dados);

        Task<ValidationResult> Update(int id, Empresa novosDados);

    }
}
