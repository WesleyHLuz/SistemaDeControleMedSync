using SistemaDeControleMedSync.API.Entities;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IConvenioRepository: IDeletaDados
    {
        Task<Convenio> Get(int id);

        Task<ICollection<Convenio>> List();

        Task<bool> Save(Convenio dados);

        Task<bool> Update(int id, Convenio novosDados);
    }
}
