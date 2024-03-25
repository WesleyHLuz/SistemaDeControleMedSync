using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.Services.ServicesInterfaces;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Services
{
    public class EmailServices : IEmailServices
    {
        public Task<bool> AtualizaEmailEntidade(IEntity entidade, Email email)
        {
            throw new NotImplementedException();
        }
    }
}
