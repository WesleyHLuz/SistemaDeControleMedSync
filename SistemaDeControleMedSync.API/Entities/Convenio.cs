using SistemaDeControleMedSync.API.Model;

namespace SistemaDeControleMedSync.API.Entities
{
    public class Convenio
    {
        public int convenioId { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public Email Email { get; set; }

        public string Cobertura { get; set; }

        public bool VerificaCobetura(string procedimento)
        {
            throw new NotImplementedException();
        }
    }
}
