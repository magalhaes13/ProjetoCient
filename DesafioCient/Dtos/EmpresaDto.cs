using DesafioCient.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCient.Dtos
{
    public class EmpresaDto : BaseEntityDto
    {
        public string Nome { get; set; }

        public string Cnpj { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string InstituicaoApoio { get; set; }
    }
}
