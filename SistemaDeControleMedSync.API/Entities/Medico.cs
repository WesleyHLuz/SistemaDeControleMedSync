using SistemaDeControleMedSync.API.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeControleMedSync.API.Entities
{
    public class Medico: IBaseModel
    {
        [Key]
        public int Id { get; set; }

        public int empresaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]

        public string Crm { get; set; }

        public ICollection<Especialidade> Especialidades { get; set; }

        public Empresa Empresa { get; set; }
    }
}
