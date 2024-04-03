using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Repository.RepositoryInterfaces
{
    public interface IDeletaDados
    {
        Task<ValidationResult> Delete(int id);
    }
}
