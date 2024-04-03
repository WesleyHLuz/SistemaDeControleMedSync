using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IUsuarioRepository: IDeletaDados
    {
        Task<Usuario> Get(int id);
        Task<List<Usuario>> List();

        Task<ValidationResult> Save(Usuario entity);

        Task<ValidationResult> Update(Usuario entidade);
    }
}
