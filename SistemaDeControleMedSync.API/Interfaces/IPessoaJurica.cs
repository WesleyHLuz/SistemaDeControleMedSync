using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Interfaces
{
    public interface IPessoaJurica: IEntity
    {
        string Cnpj { get; set; }
    }
}
