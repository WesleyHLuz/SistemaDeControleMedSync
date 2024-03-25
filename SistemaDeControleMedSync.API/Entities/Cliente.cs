using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace SistemaDeControleMedSync.API.Entities
{
    public class Cliente : IPessoaFisica
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome {  get; set; }

        [Required]
        [StringLength(50)]
        public string Sobrenome { get; set; }

        [Required]
        [StringLength(100)]
        public string Endereco { get; set; }

        [Required]
        [StringLength(11)]
        [DataType(DataType.Custom)]
        public Cpf Cpf { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.Custom)]
        public Email Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Phone]
        public string Telefone { get; set; }

        
        //public virtual Convenio? Convenio { get; set; }
        
    }
}
