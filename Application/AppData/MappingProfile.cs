using AutoMapper;
using Domain.Entities;

namespace Application.AppData
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Domain.DTO.CriadorUser, CriadorUser>();
        }
    }
}
