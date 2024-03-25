using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Interfaces
{
    public interface IPessoaFisica: IEntity
    {
        Cpf Cpf { get; set; }
    }
}
