using SistemaDeControleMedSync.API.Entities;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IMedicoEspecialidadeRepository
    {
        Task<Especialidade> BuscaEspecialidadePorMedico(Medico medico);
        Task<Medico> BuscaMedicoPorEspecialidade(Especialidade especialidade);
    }
}
