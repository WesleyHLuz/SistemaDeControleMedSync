using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IEmpresaConvenioRepository
    {
        
        Task<ICollection<Convenio>> ListConvenioPorEmpresa(Empresa empresa);

        Task<ICollection<Empresa>> ListEmpresasPorConvenio(Convenio convenio);

        
    }
}
