using SistemaDeControleMedSync.API.Entities;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IMedicoEspecialidadeRepository
    {
        Task<Especialidade> GetEspecialidadePorMedico(Medico medico);
        Task<Medico> GetMedicoPorEspecialidade(Especialidade especialidade);

        Task<ICollection<Medico>> ListMedicosPorEspecialidade(Especialidade especialidade);
        
    }
}
