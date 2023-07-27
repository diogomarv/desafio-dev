using System;
using AutoMapper;
using Cnab.Service.DictionaryHelpers;
using Desafio.Domain.DTOs.Arquivos.Layouts.Cnab;
using Desafio.Domain.Entities.Arquivos.Layouts.Cnab;
using Desafio.Domain.Enums;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Interfaces.Services;
using Desafio.Domain.RequestResponse.Responses;
using Microsoft.AspNetCore.Http;

namespace Desafio.Service.Services;

public class ArquivoCnabService : IArquivoCnabService
{
    private readonly IMapper mapper;
    private IArquivoCnabRepository repository;
    

    public ArquivoCnabService(IMapper mapper, IArquivoCnabRepository repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public IEnumerable<CnabDto> ObterTodosArquivos()
    {
        var entities = repository.ObterTodosArquivos();

        return mapper.Map<IEnumerable<CnabDto>>(entities);
    }

    public Response Upload(IFormFile arquivo)
    {
        try
        {
            using (var stream = new MemoryStream())
            {
                ProcessarArquivo(arquivo.OpenReadStream());
            }
            
            return new Response { Mensagem = "Upload concluído com sucesso!", StatusCode = 200 };
        }
        catch (Exception ex)
        {
            return new Response { Mensagem = "Houve um erro ao fazer o upload do arquivo. Erro: " + ex.Message, StatusCode = 500 };
        }
    }

    private void ProcessarArquivo(Stream stream)
    {
        List<CnabDto> arquivos = new();
        string line;

        using (StreamReader reader = new StreamReader(stream))
        {
            while ((line = reader.ReadLine()) != null)
            {
                arquivos.Add(FormatarLinhasArquivo(line));
            }
        }

        InserirArquivos(arquivos);

    }

    private CnabDto FormatarLinhasArquivo(string linha)
    {
        var tipo = linha[0..1];
        var data = linha[1..9];
        var hora = linha[42..48];

        var arquivoDto = new CnabDto
        {
            Tipo = int.Parse(linha[0..1]),
            Data = FormatarData(linha[1..9]),
            Valor = FormatarValor(linha[8..18], int.Parse(tipo)),
            Cpf = linha[19..30],
            Cartao = linha[29..42],
            Hora = FormatarDataHora(data, hora),
            DonoLoja = linha[48..62],
            NomeLoja = linha.Substring(62)
        };

        return arquivoDto;
    }

    private void InserirArquivos(List<CnabDto> arquivos)
    {
        var arquivosMapeados = mapper.Map<List<Domain.Entities.Arquivos.Layouts.Cnab.Cnab>>(arquivos);

        repository.InserirLista(arquivosMapeados);
    }
    private decimal FormatarValor(string valor, int tipo)
    {
        var sinal = TipoSinal.obterTipoSinal(tipo);

        return (sinal.Equals("+") ? 1 : -1) * (decimal.Parse(valor) / 100);
    }

    private DateTime FormatarData(string data)
    {
        var ano = data[0..4];
        var mes = data[4..6];
        var dia = data[6..8];

        return new DateTime(int.Parse(ano), int.Parse(mes), int.Parse(dia));
    }

    private DateTime FormatarDataHora(string data, string hora)
    {
        var dataConvertida = FormatarData(data);
        var horas = hora[0..2];
        var minutos = hora[2..4];
        var segundos = hora[4..6];

        return new DateTime(dataConvertida.Year, dataConvertida.Month, dataConvertida.Day, int.Parse(horas), int.Parse(minutos), int.Parse(segundos));
    }

}

