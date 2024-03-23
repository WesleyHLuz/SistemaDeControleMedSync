using SistemaDeControleMedSync.API.Model;

namespace SistemaDeControleMedSync.API.Entities
{
    public class Cliente
    {
        public int clienteId { get; set; }

        public string NomeCompleto {  get; set; }

        public Cpf Cpf { get; set; }

        public Email Email { get; set; }
        
        public string? NumCartaoSUS { get; set; }

        public Convenio? Convenio { get; set; }

        

    }
}
