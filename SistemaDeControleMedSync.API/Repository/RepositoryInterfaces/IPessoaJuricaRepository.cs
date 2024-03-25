using SistemaDeControleMedSync.API.Interfaces;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IPessoaJuricaRepository: IDeletaDados
    {
        Task<IPessoaJurica> BuscaPJPorId(int id);

        Task<List<IPessoaJurica>> BuscaTodasPF();

        Task<bool> AdicionaPF(IPessoaJurica pessoaJuridica);

        Task<bool> AtualizaPF(int id, IPessoaJurica novosDados);

    }
}
