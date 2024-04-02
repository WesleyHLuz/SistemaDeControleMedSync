using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using SistemaDeControleMedSync.API.Context;
using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Exceptions;
using SistemaDeControleMedSync.API.Repository.RepositoryInterfaces;
using SistemaDeControleMedSync.API.Services;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API;

public class ClienteRepository : IClienteRepository
{

    
    

    private readonly DefaultContext _context;

    public ClienteRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<bool> Delete(int id)
    {
        var cliente = await Get(id);

        try
        {
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);

                await _context.SaveChangesAsync();

                return true;
            }
            else return false;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
    public async Task<Cliente> Get(int id)
    {
        var cliente = await _context.Clientes.FirstAsync(x => x.Id == id);

        if(cliente is null) throw new TipoNuloRetornadoException($"Nenhum dado encontrado pelo id {id}!");
        else
        {
            return cliente;
        }
        throw new FalhaNaOperacaoException("Não foi possível efetuar a operação, tente novamente");
    }

    public async Task<ICollection<Cliente>> List()
    {
        var clientesList = await _context.Clientes.ToListAsync();
        
        if(clientesList is null) throw new TipoNuloRetornadoException("Nenhum dado encontrado!");
        else
        {
            return clientesList;
        }
        throw new FalhaNaOperacaoException("Não foi possível efetuar a operação, tente novamente");
        
    }

    public async Task<bool> Save(Cliente dados)
    {
        

        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            var valida = new ValidacaoUtils();
            try
            {

                if (dados is null) return false;
                else
                {
                    var validaCpf = valida.ValidaCpf(dados.Cpf);
                    var validaEmail = valida.ValidaEmail(dados.Email);
                    var validaTelefone = valida.ValidarTelefone(dados.Telefone);


                    if(!validaCpf.IsValid)
                    {
                        throw new Exception(validaCpf.ErrorMessage);
                    }

                    else if(!validaEmail.IsValid)
                    {
                        throw new Exception(validaEmail.ErrorMessage);
                    }

                    else if (!validaTelefone.IsValid)
                    {
                        throw new Exception(validaTelefone.ErrorMessage);
                    }


                    await _context.Clientes.AddAsync(dados);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return true;

                }

            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message, ex);
            }
        }
        
    }

    public async Task<bool> Update(int id, Cliente novosDados)
    {
        using(var transaction = await _context.Database.BeginTransactionAsync())
        {
            var valida = new ValidacaoUtils();   

            try
            {
                var dadosDesatualizados = await Get(id);

                if (dadosDesatualizados is null) throw new TipoNuloRetornadoException($"Nenhum dado encontrado pelo id {id}!");
                else {
                    var validaCpf = valida.ValidaCpf(novosDados.Cpf);
                    var validaEmail = valida.ValidaEmail(novosDados.Email);
                    var validaTelefone = valida.ValidarTelefone(novosDados.Telefone);


                    if (!validaCpf.IsValid)
                    {
                        throw new Exception(validaCpf.ErrorMessage);
                    }

                    else if (!validaEmail.IsValid)
                    {
                        throw new Exception(validaEmail.ErrorMessage);
                    }

                    else if (!validaTelefone.IsValid)
                    {
                        throw new Exception(validaTelefone.ErrorMessage);
                    }

                    dadosDesatualizados = novosDados;

                    _context.Clientes.Update(dadosDesatualizados);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return true;
                }
                
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync( );
                throw new Exception(ex.Message, ex);
            }
        }
    }

   

    
}
