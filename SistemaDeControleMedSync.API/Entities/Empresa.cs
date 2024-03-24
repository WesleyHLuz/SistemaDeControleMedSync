using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeControleMedSync.API.Entities
{
    public class Empresa : IEmpresa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string RazaoSocial { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public Email Email { get; set; }

        [Required]
        [StringLength(20)]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        [StringLength(100)]
        public string Endereco { get; set; }

        [Required]
        public Cnpj Cnpj { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }

        public virtual ICollection<Especialidade> Especialidades { get; set;}

        public virtual ICollection<Convenio> ConveniosAceitos { get; set;}
    }
}
