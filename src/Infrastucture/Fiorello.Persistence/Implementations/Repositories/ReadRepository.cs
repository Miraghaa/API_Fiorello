using Fiorello.Application.Abstraction.Repositories;
using Fiorello.Domain.Entities;
using Fiorello.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Fiorello.Persistence.Implementations.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
{
	private readonly AppDbContext _context;
	public DbSet<T> Table { get; }
	public ReadRepository(AppDbContext context)
	{
		_context = context;
		Table = _context.Set<T>();
	}

	//where serti lazim ola biler deye expres yazmisiq
	public IQueryable<T> GetAll(Expression<Func<T, bool>> expression, bool isNotTracking = true, params string[] includes)
	{
		IQueryable<T> query = Table.Where(expression).AsQueryable();
		foreach(var tablename in includes)
		{
			query = query.Include(tablename);
		}
		return isNotTracking ? query.AsNoTracking() : query;
	}

	public IQueryable<T> GetAllFiltered(Expression<Func<T, bool>> expression,
									 int skip,
									 int take,
									 bool isNotTracking = true,
									 params string[] includes)
	{
		//takeden sora yazmag olmaz skipi ve whereden evvelde yazmag olmaz
		IQueryable<T> query = Table.Where(expression).Skip(skip).Take(take).AsQueryable();
		foreach (var tablename in includes)
		{
			query = query.Include(tablename);
		}
		return isNotTracking ? query.AsNoTracking() : query;
	}

	public IQueryable<T> GetAllFilteredOrderBy(Expression<Func<T, bool>> expression,
											Expression<Func<T, object>> expressionOrderBy,
											int skip,
											int take,
											bool OrderByDesc = true,
											bool isNotTracking = true,
											params string[] includes)
	{
		IQueryable<T> query = Table.Where(expression).AsQueryable();
		query = OrderByDesc ? query.OrderByDescending(expressionOrderBy).Skip(skip).Take(take)
			: query.OrderBy(expressionOrderBy).Skip(skip).Take(take);
		foreach (var tablename in includes)
		{
			query = query.Include(tablename);
		}
		return isNotTracking? query.AsNoTracking() : query;
	}

	public async Task<T?> FindAsync(int id) => await Table.FindAsync(id);

	public async Task<T?> GetFiltered(Expression<Func<T, bool>> expression, bool isNotTracking = true)
	{
		return isNotTracking ? await Table.AsNoTracking().FirstOrDefaultAsync(expression)
			: await Table.FirstOrDefaultAsync(expression);
	}
}
