using SistemaDeControleMedSync.API.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeControleMedSync.API.Entities
{
    public class Usuario : IBaseModel
    {
        [Key]
        public int Id { get; set; }

        public int? ClienteId { get; set; } // Pode ser nulo
        public int? EmpresaId { get; set; } // Pode ser nulo

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [MinLength(8)]
        [PasswordPropertyText(true)]
        public string Senha { get; set; }

        // Relacionamento com Cliente (opcional)
        public virtual Cliente Cliente { get; set; }

        // Relacionamento com Empresa (opcional)
        public virtual Empresa Empresa { get; set; }


    }
}
