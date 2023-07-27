using Desafio.Domain.Entities.Arquivos.Layouts.Cnab;

namespace Desafio.Domain.Interfaces.Repositories;

public interface IArquivoCnabRepository : IRepository<Cnab>
{
    IEnumerable<Cnab> ObterTodosArquivos();
}

