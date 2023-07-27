using Desafio.Domain.DTOs.Arquivos.Layouts.Cnab;
using Microsoft.AspNetCore.Http;

namespace Desafio.Domain.Interfaces.Services;

public interface IArquivoCnabService
{
    RequestResponse.Responses.Response Upload(IFormFile arquivo);
    IEnumerable<CnabDto> ObterTodosArquivos();
}

