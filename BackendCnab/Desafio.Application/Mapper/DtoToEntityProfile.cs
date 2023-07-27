using AutoMapper;
using Desafio.Domain.DTOs.Arquivos.Layouts.Cnab;
using Desafio.Domain.Entities.Arquivos.Layouts.Cnab;

namespace Desafio.Application.Mapper;

public class DtoToEntityProfile : Profile
{
    public DtoToEntityProfile()
    {
        CreateMap<Domain.Entities.Arquivos.Layouts.Cnab.Cnab, CnabDto>()
            .ReverseMap();

    }
}

