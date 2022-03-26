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
            var empresas = _desafioCient.Empresas.Where(e => !e.Excluido.HasValue);
            if (!string.IsNullOrEmpty(cnpj))
            {
                empresas = empresas.Where(e => e.Cnpj == cnpj);
                if(empresas.Any())
                    throw new Exception("Fundação não encontrada!");
            }
            return _mapper.Map<List<EmpresaDto>>(empresas);
        }

        public async Task<EmpresaDto> BuscarPorId(Guid id)
        {
            var empresa = await _desafioCient.Empresas.FirstOrDefaultAsync(e => !e.Excluido.HasValue && e.Id == id);
            return _mapper.Map<EmpresaDto>(empresa);
        }

        public async Task Cadastro(EmpresaDto empresaDto)
        {
            if (await _desafioCient.Empresas.AnyAsync(e => e.Id == empresaDto.Id || e.Cnpj == empresaDto.Cnpj))
                throw new Exception("Empressa duplicada!");
            var empresa = _mapper.Map<Empresa>(empresaDto);
            empresa.Criado = DateTime.UtcNow;
            await _desafioCient.Empresas.AddAsync(empresa);
            await _desafioCient.SaveChangesAsync();
        }

        public async Task Atualizar(EmpresaDto empresaDto)
        {
            await VerificarExisteEmpresa((Guid)empresaDto.Id);
           var empresa = _mapper.Map<Empresa>(empresaDto);
            empresa.Modificado = DateTime.UtcNow;
            _desafioCient.Empresas.Update(empresa);
            await _desafioCient.SaveChangesAsync();
        }

        public async Task Deletar(Guid id)
        {
            await VerificarExisteEmpresa(id);
            var empresa = await _desafioCient.Empresas.FirstOrDefaultAsync(e=>e.Id == id);
            //model.Excluido = DateTime.UtcNow;
            _desafioCient.Empresas.Remove(empresa);
            await _desafioCient.SaveChangesAsync();
        }

        private async Task VerificarExisteEmpresa(Guid id)
        {
            if (!await _desafioCient.Empresas.AnyAsync(e => e.Id == id && !e.Excluido.HasValue))
                throw new ArgumentNullException("Empresa inválida!");
        }
    }
}