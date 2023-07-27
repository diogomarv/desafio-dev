using Desafio.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers;

[ApiController]
[Route("api/arquivo/")]
public class UploadController : ControllerBase
{
    private readonly IArquivoCnabService _service;

    public UploadController(IArquivoCnabService service)
    {
        _service = service;
    }

    [HttpPost("upload")]
    public async Task<ActionResult> Upload([FromForm] IFormFile arquivo)
    {
        if (arquivo == null)
        {
            return BadRequest("Você não selecionou nenhum arquivo. Por favor, tente novamente.");
        }

        return Ok(_service.Upload(arquivo));
    }

    [HttpGet]
    public  IActionResult Obter()
    {
        var arquivos = _service.ObterTodosArquivos();

        return Ok(arquivos);
    }

}

