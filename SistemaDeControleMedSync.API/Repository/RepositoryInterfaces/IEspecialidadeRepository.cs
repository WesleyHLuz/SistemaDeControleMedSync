using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{

    public interface IEspecialidadeRepository: IDeletaDados
    {
        Task<Especialidade> BuscaEspecialidadePorId(int id);
        Task<List<Especialidade>> BuscaTodasEspecialidades();

        Task<bool> AtualizaEspecialidade(int id, Especialidade especialidade);

        Task<bool> AdicionaEspecialidade(IBaseModel model);

    }
}
