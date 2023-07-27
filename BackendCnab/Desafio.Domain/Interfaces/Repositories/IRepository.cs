using Desafio.Domain.Entities;

namespace Desafio.Domain.Interfaces.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    IEnumerable<T> ListarTodos();
    List<T> InserirLista(List<T> entidade);
}



