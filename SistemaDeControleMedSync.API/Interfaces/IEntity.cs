using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Interfaces
{
    public interface IEntity: IBaseModel
    {
        string Telefone { get; set; }

        Email Email { get; set; }

        string Endereco { get; set; }

    }
}
