using Desafio.Domain.Entities.Arquivos.Layouts.Cnab;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infra.Repositories;

public class ArquivoCnabRepository : BaseRepository<Cnab>, IArquivoCnabRepository
{
    private readonly DbSet<Cnab> dbSet;

    public ArquivoCnabRepository(AppDbContext _context) : base(_context)
    {
        dbSet = _context.Set<Cnab>();
    }

    public IEnumerable<Cnab> ObterTodosArquivos()
    {
        return dbSet.ToList();
    }

}

