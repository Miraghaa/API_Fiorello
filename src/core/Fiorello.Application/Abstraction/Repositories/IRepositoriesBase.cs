using Fiorello.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Fiorello.Application.Abstraction.Repositories;

public interface IRepositoriesBase<T> where T : BaseEntity, new()
{
	public DbSet<T> Table { get; }

}
