using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCient.Dtos.Base
{
    public class BaseEntityDto
    {
        public Guid? Id { get; set; }

        public DateTime? Criado { get; set; }

        public DateTime? Modificado { get; set; }

        public DateTime? Excluido { get; set; }
    }
}
