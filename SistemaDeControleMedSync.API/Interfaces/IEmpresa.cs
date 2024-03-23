using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Interfaces
{
    public interface IEmpresa: IEntity
    {
        Cnpj Cnpj { get; set; }
    }
}
