namespace SistemaDeControleMedSync.API.Entities
{
    public class MedicoEspecialidade
    {

        public int medicoId { get; set; }

        public int especialidadeId { get; set; }

        public virtual Especialidade Especialidade { get; set; }
        public virtual Medico Medico { get; set; }
    }
}
