using AutoMapper;
using Desafio.Domain.DTOs.Arquivos.Layouts.Cnab;
using Desafio.Domain.Entities.Arquivos.Layouts.Cnab;

namespace Desafio.Application.Mapper;

public class DtoToEntity : Profile
{
    public DtoToEntity()
    {
        CreateMap<Domain.Entities.Arquivos.Layouts.Cnab.Cnab, CnabDto>()
            .ReverseMap();

    }
}

