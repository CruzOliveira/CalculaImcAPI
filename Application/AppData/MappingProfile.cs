using AutoMapper;
using Domain.Entities;

namespace Application.AppData
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Domain.DTO.CalculaImcApplication, CalculaImcApplication>();
            this.CreateMap<Domain.DTO.CriadorUser, CriadorUser>();
            this.CreateMap<Domain.DTO.CriadorUser, CalculaIMC>();
        }
    }
}