using Microsoft.EntityFrameworkCore;
using SistemaDeControleMedSync.API.Context;
using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Repository.RepositoryInterfaces;
using SistemaDeControleMedSync.API.ValueObject;


namespace SistemaDeControleMedSync.API;

public class ClienteRepository : IClienteRepository
{

    private readonly DefaultContext _context;

    public ClienteRepository(DefaultContext context)
    {
        _context = context;
    }

    public Task<ValidationResult> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Cliente> Get(int id)
    {
        return await _context.Clientes.FirstAsync();
    }

    public async Task<ICollection<Cliente>> List()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<ValidationResult> Save(Cliente dados)
    {
       var valida = new PessoaFisicaValidator();

       using(var transaction = await _context.Database.BeginTransactionAsync())
       {
            try
            {
                if(dados == null) return new ValidationResult {IsValid = false, ErrorMessage = "O dados do cliente não podem ser nulos"};

                else if(!valida.ValidaEmail(dados.Email).IsValid)
                {
                    return new ValidationResult {IsValid = false, ErrorMessage = valida.ValidaEmail(dados.Email).ErrorMessage};
                }
                else if(!valida.ValidaCpf(dados.Cpf).IsValid)
                {
                    return new ValidationResult {IsValid = false, ErrorMessage = valida.ValidaCpf(dados.Cpf).ErrorMessage};
                }
                else if(!valida.ValidarTelefone(dados.Telefone).IsValid)
                {
                    return new ValidationResult {IsValid = false,  ErrorMessage = valida.ValidarTelefone(dados.Telefone).ErrorMessage};
                }
                else
                {
                    await _context.Clientes.AddAsync(dados);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return new ValidationResult {IsValid = true};
                }

            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();

                throw new Exception($"Não foi possivel adicionar os dados. Erro: {ex.Message}");
            }
            
       }
    }

    public Task<ValidationResult> Update(int id, Cliente novosDados)
    {
        throw new NotImplementedException();
    }
}
