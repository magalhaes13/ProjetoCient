using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace DesafioCient.Models.Base
{
    public class BaseEntity
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Criado")]
        public DateTime Criado { get; set; }

        [Column("Modificado")]
        public DateTime? Modificado { get; set; }

        [Column("Excluido")]
        public DateTime? Excluido { get; set; }

    }
}
