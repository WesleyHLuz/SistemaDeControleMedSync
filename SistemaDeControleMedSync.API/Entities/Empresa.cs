using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.Model;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Entities
{
    public class Empresa : IEmpresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string RazaoSocial { get; set; }

        public Email Email { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public Cnpj Cnpj { get; set; }
    }
}
