using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.ValueObject;

namespace sistemadecontrolemedsyncTeste
{
    public class ClienteRepositoryTeste
    {
        [Fact]
        public void AdicionaCliente_DeveAdicionarOCliente()
        {
            var cliente = new Cliente
            {
                Id = 1,
                Nome = "Wesley",
                Email = new Email("Wesdias5@outlook.com"),
                Cpf = new Cpf("86668528015"),
                Sobrenome = "Dias da Luz",
                Endereco = "Rua Doutor Rosinha 1600",
                Telefone = "51980296640",
                Convenio = null,
            };

            var moq = new Mock<DbContext>();
        }
    }
}