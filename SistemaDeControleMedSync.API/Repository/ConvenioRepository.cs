using Microsoft.EntityFrameworkCore;
using SistemaDeControleMedSync.API.Context;
using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Repository.RepositoryInterfaces;
using SistemaDeControleMedSync.API.Services;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Repository
{
    public class ConvenioRepository : IConvenioRepository
    {
        private readonly DefaultContext _context;

        public ConvenioRepository(DefaultContext context)
        {
            _context = context;
        }
        public Task<bool> Delete(int id)
        {
            
        }

        public async Task<Convenio> Get(int id)
        {
            
            var convenio = await _context.Convenios.FirstAsync(x => x.Id == id);

            return convenio;
        }

        public async Task<ICollection<Convenio>> List()
        {
            var convenios = await _context.Convenios.ToListAsync();

            return convenios;
        }

        public async Task<bool> Save(Convenio dados)
        {
            var valida = new ValidacaoUtils();

            using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (dados == null) return false;
                    else
                    {
                        var validaCnpj = valida.ValidaCnpj(dados.Cnpj);
                        var validaEmail = valida.ValidaEmail(dados.Email);
                        var validaTelefone = valida.ValidarTelefone(dados.Telefone);

                        if (!validaCnpj.IsValid) throw new Exception(validaCnpj.ErrorMessage);
                        else if (!validaEmail.IsValid) throw new Exception(validaEmail.ErrorMessage);
                        else if (!validaTelefone.IsValid) throw new Exception(validaTelefone.ErrorMessage);

                        await _context.Convenios.AddAsync(dados);
                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();

                        return true;
                    }
                    

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message, ex); 
                }
            }
        }

        public async Task<bool> Update(int id, Convenio novosDados)
        {
            using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                var convenioDesatualizado = await Get(id);

                if (convenioDesatualizado == null || novosDados == null) return false;
                else
                {
                    if(!ValidaConvenio(convenioDesatualizado).IsValid)
                    {

                        throw new Exception(ValidaConvenio(convenioDesatualizado).ErrorMessage);
                    }
                    else if(!ValidaConvenio(novosDados).IsValid)
                    {
                        throw new Exception(ValidaConvenio(novosDados).ErrorMessage);
                    }
                }
            }
        }

        private ValidationResult ValidaConvenio(Convenio convenio)
        {
            var valida = new ValidacaoUtils();

            if (!valida.ValidaCpf(convenio.Cnpj).IsValid && !valida.ValidaEmail(convenio.Email).IsValid && !valida.ValidarTelefone(convenio.Telefone).IsValid)
            {
                return new ValidationResult { IsValid = false, ErrorMessage = "Convênio inválido" };
            }

            return new ValidationResult { IsValid = true };
        }
    }
}
