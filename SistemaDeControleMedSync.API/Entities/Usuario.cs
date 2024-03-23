using SistemaDeControleMedSync.API.Interfaces;

namespace SistemaDeControleMedSync.API.Entities
{
    public class Usuario : IBaseModel
    {
        public int Id {  get; set; }

        public int clienteId { get; set; }
        public string Nome {get; set; }

        public string Senha { get; set; }


    }
}
