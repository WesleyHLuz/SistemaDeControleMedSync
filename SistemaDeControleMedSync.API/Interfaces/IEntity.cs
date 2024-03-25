using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Interfaces
{
    public interface IEntity: IBaseModel, IEmailConfig
    {
        string Telefone { get; set; }

        string Endereco { get; set; }

    }
}
