using AutoMapper;
using DesafioCient.Dtos;
using DesafioCient.Models;
using DesafioCient.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCient.Business
{
    public class FormularioBusiness
    {
        private readonly DesafioCientContext _desafioCient;
        private readonly IMapper _mapper;
        public FormularioBusiness(DesafioCientContext desafioCient, IMapper mapper)
        {
            _desafioCient = desafioCient;
            _mapper = mapper;
        }

        public async Task<List<EmpresaDto>> ListarEmpresas(string cnpj)
        {
            var empresa = _desafioCient.Empresas.Where(e => !e.Excluido.HasValue);
            if (!string.IsNullOrEmpty(cnpj)) empresa = empresa.Where(e => e.Cnpj == cnpj);
            return _mapper.Map<List<EmpresaDto>>(empresa);
        }

        public async Task<EmpresaDto> BuscarPorId(Guid id)
        {
            var empresa = _desafioCient.Empresas.Where(e => !e.Excluido.HasValue && e.Id == id);
            return _mapper.Map<EmpresaDto>(empresa);
        }
    }
}