using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Interfaces
{
    public interface IPessoaFisica: IEntity
    {
        string Cpf { get; set; }
    }
}
