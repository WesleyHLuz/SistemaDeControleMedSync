using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IEmpresaMedicoRepository
    {
        
        Task<ICollection<Medico>> ListMedicosPorEmpresa(Empresa empresa);

        Task<ICollection<Empresa>> ListEmpresasPorMedicos(Medico medico);

        
    }
}
