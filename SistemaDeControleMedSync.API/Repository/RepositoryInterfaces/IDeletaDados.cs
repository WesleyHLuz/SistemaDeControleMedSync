namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IDeletaDados
    {
        Task<bool> Delete(int id);
    }
}
