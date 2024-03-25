using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Services.ServicesInterfaces
{
    public interface IEmailServices
    {
        Task<bool> AtualizaEmailEntidade(IEntity entidade, Email email);
    }
}
