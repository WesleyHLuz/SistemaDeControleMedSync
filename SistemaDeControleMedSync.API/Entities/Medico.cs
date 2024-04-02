using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeControleMedSync.API.Entities
{
    public class Medico: IPessoaFisica
    {
        [Key]
        public int Id { get; set; }

        public int empresaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        public string Crm { get; set; }

        [Required]
        public ICollection<Empresa> Empresa { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        [StringLength(20)]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        [StringLength (100)]
        public string Endereco { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        public ICollection<Especialidade> Especialidades { get; set; }
    }
}
