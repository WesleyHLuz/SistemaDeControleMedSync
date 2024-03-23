

namespace SistemaDeControleMedSync.API.Entities
{
    public class Convenio
    {
        public int Id { get; set; }

        public Empresa Empresa { get; set; }

        public string Cobertura { get; set; }

        public bool VerificaCobertura(string procedimento)
        {
            throw new NotImplementedException();
        }
    }
}
