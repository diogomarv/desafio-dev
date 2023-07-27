using AutoMapper;
using Desafio.Domain.DTOs.Arquivos.Layouts.Cnab;

namespace Desafio.Application.Mapper;

public class EntityToDtoProfile : Profile
{
    public EntityToDtoProfile()
    {
        CreateMap<CnabDto, Domain.Entities.Arquivos.Layouts.Cnab.Cnab>()
            .ReverseMap();

    }
}
