using DesafioCient.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//seu nome, CNPJ, e-mail, telefone e a instituição que ela apoia
namespace DesafioCient.Models
{
    [Table("Empresa")]
    public class Empresa : BaseEntity
    {
        [StringLength(50)]
        [Column("Nome")]
        [Required]
        public string Nome { get; set; }

        [StringLength(20)]
        [Column("Cnpj")]
        [Required]
        public string Cnpj { get; set; }

        [StringLength(30)]
        [Column("Email")]
        public string Email { get; set; }

        [StringLength(15)]
        [Column("Telefone")]
        public string Telefone { get; set; }

        [StringLength(50)]
        [Column("InstituicaoApoio")]
        public string InstituicaoApoio { get; set; }

    }
}
