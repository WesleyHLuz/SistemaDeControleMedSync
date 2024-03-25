using SistemaDeControleMedSync.API.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeControleMedSync.API.Entities
{
    public class Especialidade : IBaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        // Adicionando referência para Empresa
        public int EmpresaId { get; set; }
        //public virtual Empresa Empresa { get; set; }

        // Relacionamento com Médico
        //public virtual ICollection<Medico> Medicos { get; set; }
    }

}
