using SistemaDeControleMedSync.API.Interfaces;
using SistemaDeControleMedSync.API.ValueObject;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeControleMedSync.API.Entities
{
    public class Convenio : IPessoaJurica
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string NumeroConvenio {get; set;}

        [Required]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(50)")]
        public string Nome { get; set; }

        

        [Required]
        
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(50)")]
        public string Cobertura { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(50)")]
        public string Cnpj { get; set; }

        [Required]
        [Phone]
        [Column(TypeName = "varchar(50)")]
        
        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Endereco { get; set; }

        public virtual ICollection<Cliente> Clientes {get; set;}
        public virtual ICollection<Empresa> Empresa { get; set; }

    }


}
