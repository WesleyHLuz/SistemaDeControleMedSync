using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IUsuarioRepository: IDeletaDados, IValidaDados
    {
        Task<Usuario> Get(int id);
        Task<List<Usuario>> List();

        Task<bool> Save(Usuario entity);

        Task<bool> Update(Usuario entidade);
    }
}
