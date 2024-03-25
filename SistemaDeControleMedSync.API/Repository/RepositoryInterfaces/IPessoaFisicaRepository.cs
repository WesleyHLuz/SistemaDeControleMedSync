using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IPessoaFisicaRepository: IDeletaDados
    {
        Task<IPessoaFisica> BuscaPessoaFisicaPorId(int id);

        Task<List<IPessoaFisica>> BuscaPessoaFisica();

        Task<bool> AdicionaPessoaFisica(IPessoaFisica pessoaFisica);

        Task<bool> AtualizaPessoaFisica(int id, IPessoaFisica novosDados);

    }
}
