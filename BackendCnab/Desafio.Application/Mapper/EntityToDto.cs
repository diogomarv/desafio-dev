using AutoMapper;
using Desafio.Domain.DTOs.Arquivos.Layouts.Cnab;

namespace Desafio.Application.Mapper;

public class EntityToDto : Profile
{
    public EntityToDto()
    {
        CreateMap<CnabDto, Domain.Entities.Arquivos.Layouts.Cnab.Cnab>()
            .ReverseMap();

    }
}
