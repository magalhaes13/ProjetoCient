using System.Linq;
using AutoMapper;
using DesafioCient.Dtos;
using DesafioCient.Models;

namespace ProAgil.WebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Empresa, EmpresaDto>().ReverseMap();
            CreateMap<EmpresaDto, Empresa>().ReverseMap();
        }
    }
}