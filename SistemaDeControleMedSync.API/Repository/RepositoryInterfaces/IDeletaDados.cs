namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IDeletaDados
    {
        Task<bool> DeletaDados(int id);
    }
}
