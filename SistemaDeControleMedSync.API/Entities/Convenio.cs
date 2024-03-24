using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeControleMedSync.API.Entities
{
    public class Convenio : IEmpresa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        public Empresa Empresa { get; set; }

        [Required]
        [StringLength(50)]
        public string Cobertura { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public Cnpj Cnpj { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public Email Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Endereco { get; set; }
    }


}
