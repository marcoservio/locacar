using AutoMapper;

using LocaCar.Api.Dtos;
using LocaCar.Api.Models;

namespace LocaCar.Api.Mappings
{
    public class EntitiesToDtoMappingProfile : Profile
    {
        public EntitiesToDtoMappingProfile()
        {
            CreateMap<Carro, CarroDto>().ReverseMap();
        }
    }
}
