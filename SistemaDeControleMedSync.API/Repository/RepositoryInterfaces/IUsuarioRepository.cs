using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IUsuarioRepository: IDeletaDados
    {
        Task<Usuario> BuscaUsuarioPorId(int id);
        Task<List<Usuario>> BuscaTodosUsuarios();

        Task<bool> AdicionaUsuario(IEntity entity);

        Task<bool> AtualizaSenhaUsuario(IEntity entidade, string senhaCriptografada);
    }
}
