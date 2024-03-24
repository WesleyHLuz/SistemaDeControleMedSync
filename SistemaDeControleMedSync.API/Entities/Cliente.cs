using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace SistemaDeControleMedSync.API.Entities
{
    public class Cliente : ICliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Nome {  get; set; }

        [Required]
        [StringLength(50)]
        public required string Sobrenome { get; set; }

        [Required]
        [StringLength(100)]
        public required string Endereco { get; set; }

        [Required]
        [StringLength(11)]
        [DataType(DataType.Custom)]
        public required Cpf Cpf { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.Custom)]
        public required Email Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Phone]
        public required string Telefone { get; set; }

        [DataType(DataType.Custom)]
        public Convenio? Convenio { get; set; }
        
    }
}
