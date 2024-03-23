using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Interfaces
{
    public interface ICliente: IEntity
    {
        Cpf Cpf { get; set; }
    }
}
