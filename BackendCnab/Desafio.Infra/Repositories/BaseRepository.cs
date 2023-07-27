using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infra.Repositories;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;
    private DbSet<T> databaseSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        databaseSet = _context.Set<T>();
    }

    public IEnumerable<T> ListarTodos()
    {
        return databaseSet.ToList();
    }

    public List<T> InserirLista(List<T> entidade)
    {
        databaseSet.AddRange(entidade);

        _context.SaveChanges();

        return entidade;
    }
}
