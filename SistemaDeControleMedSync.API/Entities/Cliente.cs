using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Entities
{
    public class Cliente : ICliente
    {
        
        public int Id { get; set; }

        public string Nome {  get; set; }

        public string Sobrenome { get; set; }

        public string Endereco { get; set; }

        public Cpf Cpf { get; set; }

        public Email Email { get; set; }
        public string Telefone { get; set; }
        
        public Convenio? Convenio { get; set; }
        
    }
}
