using Microsoft.EntityFrameworkCore;
using SistemaDeControleMedSync.API.Context;
using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.Repository.RepositoryInterfaces;
using SistemaDeControleMedSync.API.Services;
using System.Text.RegularExpressions;

namespace SistemaDeControleMedSync.API.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {

        private readonly DefaultContext _context;

        public EmpresaRepository(DefaultContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var empresa = await Get(id);

            try
            {
                if (empresa != null)
                {
                    _context.Empresas.Remove(empresa);

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

        public async Task<Empresa> Get(int id)
        {
            var empresa = await _context.Empresas.FirstAsync(x => x.Id == id); ;

            if (empresa == null) throw new TipoNuloRetornadoException($"Nenhum dado encontrado pelo id {id}!");

            return empresa;
        }

        public async Task<ICollection<Empresa>> List()
        {
            var clientes = await _context.Empresas.ToListAsync();

            if (clientes == null) throw new  TipoNuloRetornadoException($"Nenhum dado encontrado!");

            return clientes;
        }

        public async Task<bool> Save(Empresa dados)
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


                        if(!validaCnpj.IsValid)
                    {
                            throw new Exception(validaCnpj.ErrorMessage);
                        }

                        else if (!validaEmail.IsValid)
                        {
                            throw new Exception(validaEmail.ErrorMessage);
                        }

                        else if (!validaTelefone.IsValid)
                        {
                            throw new Exception(validaTelefone.ErrorMessage);
                        }

                        await _context.Empresas.AddAsync(dados);

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

        public async Task<bool> Update(int id, Empresa novosDados)
        {
            var valida = new ValidacaoUtils();

            using(var transaction = await _context.Database.BeginTransactionAsync())
            {
               
                try
                {
                    var empresaExistente = await Get(id);

                    if (novosDados == null || empresaExistente == null) return false;
                    else
                    {
                        var validaCnpj = valida.ValidaCnpj(novosDados.Cnpj);
                        var validaEmail = valida.ValidaEmail(novosDados.Email);
                        var validaTelefone = valida.ValidarTelefone(novosDados.Telefone);

                        if (!validaCnpj.IsValid)
                        {
                            throw new Exception(validaCnpj.ErrorMessage);
                        }

                        else if (!validaEmail.IsValid)
                        {
                            throw new Exception(validaEmail.ErrorMessage);
                        }

                        else if (!validaTelefone.IsValid)
                        {
                            throw new Exception(validaTelefone.ErrorMessage);
                        }

                        empresaExistente = novosDados;

                        _context.Empresas.Update(empresaExistente);
                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }

        }

        public bool ValidarDocumento(string valor)
        {
            // Remove caracteres não numéricos do CNPJ
            string cnpjLimpo = new string(valor.Where(char.IsDigit).ToArray());

            // Verifica se o CNPJ tem 14 dígitos
            if (cnpjLimpo.Length != 14)
                return false;

            // Calcula o primeiro dígito verificador
            int[] multiplicadoresPrimeiroDigito = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(cnpjLimpo[i].ToString()) * multiplicadoresPrimeiroDigito[i];
            }
            int resto = soma % 11;
            int primeiroDigitoVerificador = resto < 2 ? 0 : 11 - resto;

            // Calcula o segundo dígito verificador
            int[] multiplicadoresSegundoDigito = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(cnpjLimpo[i].ToString()) * multiplicadoresSegundoDigito[i];
            }
            resto = soma % 11;
            int segundoDigitoVerificador = resto < 2 ? 0 : 11 - resto;

            // Verifica se os dígitos verificadores calculados são iguais aos dígitos verificadores fornecidos
            return int.Parse(cnpjLimpo[12].ToString()) == primeiroDigitoVerificador &&
                   int.Parse(cnpjLimpo[13].ToString()) == segundoDigitoVerificador;
        }

        public bool ValidarEmail(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return false;

            // Padrão de validação de e-mail utilizando uma expressão regular
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Verifica se o endereço de e-mail corresponde ao padrão
            return Regex.IsMatch(valor, pattern);
        }
    }
}
