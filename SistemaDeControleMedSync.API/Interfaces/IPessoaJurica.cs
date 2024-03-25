using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Interfaces
{
    public interface IPessoaJurica: IEntity
    {
        Cnpj Cnpj { get; set; }
    }
}
